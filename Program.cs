using Agents.DAL;
using Agents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            ////יצירת סוכנים
            //Agent agent1 = new Agent(1,"y","yakir","live","kgc",7);
            //Agent agent2 = new Agent(2,"m","merav","live","jlm",8);
            //Agent agent3 = new Agent(3,"i","itay","live","bbc",9);
            //Agent agent4 = new Agent(4,"j","jossef","live","bsh",10);
            //Agent agent5 = new Agent(5,"z","zohara","live","tlv",11);

            ////יצירת מופע של דאל שמדבר עם הדאטה בייס
            //AgentDAL agentDAL = new AgentDAL();

            ////הוספת סוכן 
            //agentDAL.AddAgent(agent1);
            //agentDAL.AddAgent(agent2);
            //agentDAL.AddAgent(agent3);
            //agentDAL.AddAgent(agent4);
            //agentDAL.AddAgent(agent5);
            
            ////מחיקת סוכן
            //agentDAL.DeleteAgent(5);

            ////הדפסת רשימת הסוכנים
            //List<Agent> agentList = agentDAL.GetAllAgents();
            //foreach (var agent in agentList)
            //{
            //    Console.WriteLine($"ID: {agent.Id}, Agent: {agent.CodeName}, Real Name: {agent.RealName}, Location: {agent.Location}, missionsCompleted: {agent.MissionsCompleted}");
            //}
        }
    }
}
