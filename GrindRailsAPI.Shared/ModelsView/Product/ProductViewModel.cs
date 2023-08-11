namespace GrindRailsAPI.Shared.ModelsView.Product
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public bool? Active { get; set; }

        public string Description { get; set; }

        public string EAN { get; set; }

        public decimal CostValue { get; set; }

        public decimal SalePrice { get; set; }
    }
}
