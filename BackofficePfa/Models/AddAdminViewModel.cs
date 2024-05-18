namespace BackofficePfa.Models
{

    /// <summary>
    /// The view model is used to bind data when submit the form
    /// </summary>
    public class AddAdminViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
    }
}
