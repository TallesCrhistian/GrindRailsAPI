namespace GrindRailsAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public bool? Active { get; set; } = true;
        public string Description { get; set; }
        public string EAN { get; set; }
        public decimal CostValue { get; set; }
        public decimal SalePrice { get; set; }
    }
}
