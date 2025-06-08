using Agents.DAL;
using Agents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    internal class Menu
    {
        public Menu()
        {
            AgentDAL agentDAL = new AgentDAL();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine();
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Add agant");
                Console.WriteLine("2. Show all agents");
                Console.WriteLine("3. Delete agent");
                Console.WriteLine("4. Search Agents By Code Name");
                Console.WriteLine("5. Update Agent Location");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Your choise (1-5): ");
                Console.WriteLine(" ");

                string choise = Console.ReadLine();
                Console.WriteLine(" ");

                switch (choise)
                {
                    case "1":
                        Console.Write("code name: ");
                        string codeName = Console.ReadLine();

                        Console.Write("real name: ");
                        string realName = Console.ReadLine();

                        Console.Write("location: ");
                        string location = Console.ReadLine();

                        Console.Write("status: ");
                        string status = Console.ReadLine();

                        Console.Write("missions Completed: ");
                        int missionsCompleted = int.Parse(Console.ReadLine());
                        //הפעלת פונקציית אד אייג'נט
                        Agent newAgent = new Agent(0, codeName, realName, location, status, missionsCompleted);
                        agentDAL.AddAgent(newAgent);
                        Console.WriteLine("Agent added successfully!");
                        Console.WriteLine(" ");
                        break;

                    case "2":
                        List<Agent> agentList = agentDAL.GetAllAgents();
                        foreach (var agent in agentList)
                        {
                            Console.WriteLine($"ID: {agent.Id}, Code Name: {agent.CodeName}, Real Name: {agent.RealName}, Location: {agent.Location}, missions Completed: {agent.MissionsCompleted}.");
                        }
                        Console.WriteLine(" ");
                        break;

                    case "3":
                        Console.Write("Enter the agent ID to delete: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        agentDAL.DeleteAgent(idToDelete);
                        Console.WriteLine("The agent was successfully deleted!");
                        Console.WriteLine(" ");
                        break;

                    case "4":
                        Console.WriteLine("Enter code name to search: ");
                        string codeNameToSearch = Console.ReadLine();
                        List<Agent> searchResults = agentDAL.SearchAgentsByCode(codeNameToSearch);

                        foreach (var agent in searchResults)
                        {
                            Console.WriteLine($"ID: {agent.Id}, Agent: {agent.CodeName}, Real Name: {agent.RealName}, Location: {agent.Location}, Status: {agent.Status}, Missions Completed: {agent.MissionsCompleted}");
                        }
                        break;

                    case "5":
                        Console.Write("Enter the agent ID to update location: ");
                        int idToUpdate = int.Parse(Console.ReadLine());

                        Console.Write("Enter new location: ");
                        string newLocation = Console.ReadLine();

                        agentDAL.UpdateAgentLocation(idToUpdate, newLocation);
                        break;


                    case "6":
                        flag = false;
                        Console.WriteLine("GoodByeeee...");
                        break;
                }

            }

        }
    }
}
