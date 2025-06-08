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
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Add agant");
                Console.WriteLine("2. Show all agents");
                Console.WriteLine("3. Delete agent");
                Console.WriteLine("4. Exit");
                Console.Write("Your choise (1-4): ");

                string choise = Console.ReadLine();

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
                        break;

                    case "2":
                        List<Agent> agentList = agentDAL.GetAllAgents();
                        foreach (var agent in agentList)
                        {
                            Console.WriteLine($"ID: {agent.Id}, Agent: {agent.CodeName}, Real Name: {agent.RealName}, Location: {agent.Location}, missionsCompleted: {agent.MissionsCompleted}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter the agent ID to delete: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        agentDAL.DeleteAgent(idToDelete);
                        Console.WriteLine("The agent was successfully deleted!");
                        break;

                    case "4":
                        flag = false;
                        Console.WriteLine("GoodByeeee...");
                        break;
                }

            }

        }
    }
}
