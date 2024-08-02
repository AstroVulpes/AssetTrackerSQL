namespace WeeklyMiniProject_w30_31
{
    public abstract class Product // Class from which children product type objects inherit
    {
        public int ProductID { get; set; }
        public virtual string Type { get;  set; } = "Product";
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; } //SEK

        public Product()
        {
            
        }
    }

    public class Laptop : Product
    {
        public override string Type { get; set; } = "Computer";
        public Laptop() : base() { }

    }

    public class MobilePhone : Product
    {
        public override string Type { get; set; } = "Mobile phone";
        public MobilePhone() : base() { }
    }
}