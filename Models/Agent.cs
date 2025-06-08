using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents.Models
{
    class Agent
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public string RealName { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int MissionsCompleted { get; set; }
    

        public Agent(int Id, string CodeName, string RealName, string Status, string Location, int MissionsCompleted)
        {
            this.Id = Id;
            this.CodeName = CodeName;
            this.RealName = RealName;
            this.Location = Location;
            this.Status = Status;
            this.MissionsCompleted = MissionsCompleted;
        }
    }

}
