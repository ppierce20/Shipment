namespace Packages
{
    public static class PackageExtensions
    {
        extension (Package source)
        {
            public decimal Cost => source.CostCalculator.CalculatePackageCost(source);
            public PackageCategory Category => source.CategoryAssigner.CalculatePackageCategory(source);
        }
    }
}
