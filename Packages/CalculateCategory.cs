namespace Packages;

public class CalculateCategory : ICalculateCategory
{
    public PackageCategory CalculatePackageCategory(IPackage package)
    {
        if (package.Weight <= 1.0m && package.Length <= 30 && package.Width <= 30 && package.Height <= 30)
            return PackageCategory.Small;
        if (package.Weight <= 5.0m && package.Length <= 60 && package.Width <= 60 && package.Height <= 60)
            return PackageCategory.Medium;
        return PackageCategory.Large;
    }
}
