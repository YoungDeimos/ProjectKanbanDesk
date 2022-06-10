namespace ProjectKanbanDesk.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public List<Story> Stories { get; set; } = new();
    }
}
