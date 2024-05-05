namespace BackofficePfa.Models
{
    public class AddInstructorViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; } = null;
        public string? Subject { get; set; }
        public bool NightClasses { get; set; }
    }
}
