using Packages;

namespace PackageTests
{
    public class PackageTests
    {
        [Theory]
        [InlineData(5, 20, 30, 40, 10)]
        [InlineData(1, 20, 20, 20, 10)]
        [InlineData(0.1, 30, 30, 30, 10)]
        [InlineData(100, 40, 40, 40, 10)]
        [InlineData(100, 60, 60, 60, 20)]
        [InlineData(100, 100, 100, 100, 30)]
        public void CostTests(decimal weight, decimal length, decimal width, decimal height, decimal cost)
        {
            var package = new Package(new CalculateCosts(), new CalculateCategory())
            {
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            Assert.Equal(package.Cost, cost);
        }

        [Theory]
        [InlineData(1, 20, 20, 20, PackageCategory.Small)]
        [InlineData(0.1, 30, 30, 30, PackageCategory.Small)]
        [InlineData(1.1, 20, 20, 20, PackageCategory.Medium)]
        [InlineData(5, 20, 30, 40, PackageCategory.Medium)]
        [InlineData(5, 40, 40, 40, PackageCategory.Medium)]
        [InlineData(10, 20, 20, 20, PackageCategory.Large)]
        [InlineData(100, 40, 40, 40, PackageCategory.Large)]
        [InlineData(100, 60, 60, 60, PackageCategory.Large)]
        [InlineData(100, 100, 100, 100, PackageCategory.Large)]
        public void CategoryTests(decimal weight, decimal length, decimal width, decimal height, PackageCategory packageCategory)
        {
            var package = new Package(new CalculateCosts(), new CalculateCategory())
            {
                Weight = weight,
                Length = length,
                Width = width,
                Height = height
            };

            Assert.Equal(package.Category, packageCategory);
        }
    }
}
