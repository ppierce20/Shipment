namespace Packages
{
    public class Package : IPackage
    {
        public readonly ICalculateCosts CostCalculator;
        public readonly ICalculateCategory CategoryAssigner;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public Package(ICalculateCosts calculateCosts, ICalculateCategory calculateCategory)
        {
            CostCalculator = calculateCosts;
            CategoryAssigner = calculateCategory;
            Name = string.Empty;
        }
    }
}
