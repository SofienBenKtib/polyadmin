namespace BackofficePfa.Models

{

    /// <summary>
    /// This needs to be fixed in order to create dynamic cards list for the home page
    /// </summary>
    public class IndexCardModel : CardData
    {
        public List<CardData> Cards { get; set; }
        public void OnGet()
        {
            Cards = new List<CardData>
            {
                new() {Title="Card1", Description="test", Color="#153448" },
                new() {Title="Card1", Description="test", Color="#3C5B6F" },
                new() {Title="Card1", Description="test", Color="#948979" },
            };
        }
    }
}
