namespace ChatApp.Models
{
    public class Users : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static implicit operator Users(UserRegister userRegister)
        {
            return new Users
            {
                Name = userRegister.Name,
                Phone = userRegister.Phone,
                Password = userRegister.Password,
            };
        }
    }
}
