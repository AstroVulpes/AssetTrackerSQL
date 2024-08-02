namespace WeeklyMiniProject_w30_31
{
    public class Office // Class that creates office-type objects
    {
        public int OfficeID { get; set; }
        public string Name { get; set; } = "";
        public string Currency { get; set; } = "";
        public virtual List<Product> Products { get; set; } = new List<Product>(); // List of products at each office

        public Office()
        {
            

        }
    }
}
