using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.BLL.Dtos.ApplicationUserDto
{
    public class RegesterStudentDto
    {
        [Required(ErrorMessage = "Username is required"), StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]

        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "Password confirmation is required")]

        [Compare("Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        // public TypeUser UserType { get; set; } = TypeUser.Student;

    }
    public class RegesterAdminDto:RegesterStudentDto
    {
        [Required(ErrorMessage = "UserType is required")]

        public TypeUser UserType { get; set; } = TypeUser.Student;
        public bool IsAdminCreated { get; set; }

    }
}
