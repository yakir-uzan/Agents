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
                agents.Add(MapReaderToAgent(reader));
            }
            reader.Close();
            return agents;
        }
        //חיפוש סוכן לפי איי-די
        public Agent GetAgentById(int agentId)
        {
            Agent agent = null;

            string query = $"SELECT id, codeName, realName, location, status, missionsCompleted FROM agents WHERE id = {agentId}";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                agent = MapReaderToAgent(reader);
            }

            reader.Close();

            return agent;
        }


        //חיפוש סוכן לפי שם קוד
        public List<Agent> SearchAgentsByCode(string codename)
        {
            List<Agent> agents = new List<Agent>();

            string query = "SELECT id, codeName, realName, location, status, missionsCompleted FROM agents WHERE codeName = '" + codename + "'";
            MySqlCommand cmd = new MySqlCommand(query, _conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                agents.Add(MapReaderToAgent(reader));
            }

            reader.Close();
            return agents;
        }



        //עידכון מיקום הסוכן לפי איי-די
        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            string query = $"UPDATE agents SET location = '{newLocation}' WHERE id = {agentId}";
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

        //הדפסת סוכן
        private Agent MapReaderToAgent(MySqlDataReader reader)
        {
            return new Agent
            (
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetString(4),
                reader.GetInt32(5)
            );
        }




    }
}
