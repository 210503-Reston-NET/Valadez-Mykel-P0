namespace Models
{
    public class Item
    {
        public string Name { get; }
        public float Price { get; }
        public string Category { get; }
        public string Description { get; }

        public Item(string name, float price, string category, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Description = description;
        }
    }
}