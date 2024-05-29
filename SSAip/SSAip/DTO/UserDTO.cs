namespace SSAip.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }
    }
}
