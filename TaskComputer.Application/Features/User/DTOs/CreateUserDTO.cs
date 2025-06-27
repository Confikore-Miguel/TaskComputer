namespace TaskComputer.Application.Features.User.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public bool Active { get; set; }
        public int IdRole { get; set; }
        public int? IdUserAction { get; set; }
    }
    public class GetUser
    {
        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public bool Active { get; set; }
        public bool Removed { get; set; }
        public int IdRole { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateRemoved { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? IdUserAction { get; set; }
        public int? IdUserCreated { get; set; }
    }
}
