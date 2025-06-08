using Agents.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Agents.DAL
{
    internal class AgentDAL
    {
        private string connStr = "server=localhost;username=root;password=;database=Agents";
        private MySqlConnection _conn;

        public AgentDAL()
        {
            _conn = new MySqlConnection(connStr);
            _conn.Open();
            Console.WriteLine("Connection success");
        }

        //הוספת סוכן
        public void AddAgent(Agent agent)
        {
            string query = $"INSERT INTO agents (codeName, realName, location, status, missionsCompleted) " +
                           $"VALUES ('{agent.CodeName}', '{agent.RealName}', '{agent.Location}', '{agent.Status}', {agent.MissionsCompleted})";

            MySqlCommand cmd = new MySqlCommand(query, _conn);
            cmd.ExecuteNonQuery();
        }

        //הדפסת רשימת הסוכנים
        public List<Agent> GetAllAgents()
        {
            List<Agent> agents = new List<Agent>();

            string query = "SELECT id, codeName, realName, location, status, missionsCompleted FROM agents";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string codeName = reader.GetString(1);
                string realName = reader.GetString(2);
                string location = reader.GetString(3);
                string status = reader.GetString(4);
                int missionsCompleted = reader.GetInt32(5);

                Agent agent = new Agent(id, codeName, realName, location, status, missionsCompleted);
                agents.Add(agent);
            }

            reader.Close();

            return agents;
        }

        //עידכון מיקום הסוכן לפי איי-די
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            string query = $"SELECT agents SET location = {newLocation} WHERE id = {agentId}";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Agent with id {agentId} location updated to {newLocation}");
        }

        //מחיקת סוכן
        public void DeleteAgent(int agentId)
        {
            string query = $"DELETE FROM agents WHERE id = {agentId}";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Agent with id {agentId} deleted");
        }
    }
}
