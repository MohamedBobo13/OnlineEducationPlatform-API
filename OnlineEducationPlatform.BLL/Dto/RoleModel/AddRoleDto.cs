using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dto.RoleModel
{
    public class AddRoleDto
    {
        [Required]
        public string Id {  get; set; }
        [Required]
        public string RoleName { get; set; }

    }
}
