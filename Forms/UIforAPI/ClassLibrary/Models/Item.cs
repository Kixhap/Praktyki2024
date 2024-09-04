namespace ClassLibrary.Models
{
    public class Item
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool ShouldSerializeId()
        {
            return Id.HasValue;
        }
    }
}
