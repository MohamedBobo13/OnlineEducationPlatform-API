namespace OnlineEducationPlatform.BLL.Dto.ApplicationUserDto
{
    public class AuthModel
    {
        public List<string> Errors { get; set; }=new List<string>();
        public string message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; }
        public DateTime ExpairationDate { get; set; }
        public string Type { get; set; }
    }

    
}
