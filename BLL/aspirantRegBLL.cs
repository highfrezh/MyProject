using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electoric_Voting_System.BLL
{
    class aspirantRegBLL
    {
        public int AspirantID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int AdmissionNo { get; set; }
        public string Department { get; set; }
        public string Post { get; set; }
        public string Religion { get; set; }
        public string CurrentLevel { get; set; }
        public byte[] ImageUrl { get; set; }
        public string Sex { get; set; }
        public int Phone { get; set; }
        public DateTime DateTime { get; set; }
    }
}
