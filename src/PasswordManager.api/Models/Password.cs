namespace PasswordManager.api.Models
{
    public class Password
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PasswordValue { get; set; }
        public required string Url { get; set; }
        public int UserId { get; set; }
        public required string Categorie { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}