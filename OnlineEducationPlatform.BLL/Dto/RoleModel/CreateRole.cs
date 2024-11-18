using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.RoleModel
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
