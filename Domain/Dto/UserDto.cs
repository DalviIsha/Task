namespace TestMS.API.Controllers
{
    public class UserDto
    {
        public Guid UserId {get; set;}
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public string EmailId { get;  set; }
        public string Country { get;  set; }
        public DateTime CreatedTS { get;  set; }
        
    }
}