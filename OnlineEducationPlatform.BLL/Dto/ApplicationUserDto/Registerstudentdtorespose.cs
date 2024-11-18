using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.ApplicationUserDto
{
    public class Registerstudentdtorespose
    {
        public string message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpairationDate { get; set; }
        public string Type { get; set; }
    }
}
