using Packages;

namespace PackageTests
{
    public class ShipmentTests
    {
        private readonly List<IPackage> _packages;

        public ShipmentTests()
        {
            var calcCost = new CalculateCosts();
            var calcCat = new CalculateCategory();
            _packages =
            [
                new Package(calcCost, calcCat)
                {
                    Weight = 1,
                    Length = 20,
                    Width = 20,
                    Height = 20,
                    Name = "Box B"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 0.1m,
                    Length = 30,
                    Width = 30,
                    Height = 30,
                    Name = "Box C"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 1.1m,
                    Length = 20,
                    Width = 20,
                    Height = 20,
                    Name = "Box C"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 5,
                    Length = 20,
                    Width = 30,
                    Height = 40,
                    Name = "Box A"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 5,
                    Length = 40,
                    Width = 40,
                    Height = 40,
                    Name = "Box A"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 10,
                    Length = 20,
                    Width = 20,
                    Height = 20,
                    Name = "Box D"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 100,
                    Length = 40,
                    Width = 40,
                    Height = 40,
                    Name = "Box C"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 100,
                    Length = 60,
                    Width = 60,
                    Height = 60,
                    Name = "Box E"
                },
                new Package(calcCost, calcCat)
                {
                    Weight = 100,
                    Length = 100,
                    Width = 100,
                    Height = 100,
                    Name = "Box C"
                }
            ];
        }

        [Fact]
        public void AddPackageTests()
        {
            var shipment = new Shipment()
            {
                Name = "Test Shipment",
                Description = "This is a test shipment",
            };

            Assert.Empty(shipment.Packages);
            foreach (var package in _packages)
            {
                shipment.AddPackage(package);
                Assert.Contains(package, shipment.Packages);
            }
        }

        [Fact]
        public void RemovePackageTests()
        {
            var shipment = new Shipment()
            {
                Name = "Test Shipment",
                Description = "This is a test shipment",
            };

            Assert.Empty(shipment.Packages);
            shipment.Packages.AddRange(_packages);

            Assert.False(shipment.RemovePackage(-1)); //can't remove negative index
            Assert.False(shipment.RemovePackage(_packages.Count)); //can't remove index equal to count. 0 based index (0 -> count-1)

            for (var i = 0; i < _packages.Count; i++)
            {
                var package = _packages[i];
                Assert.Contains(package, shipment.Packages);
                var result = shipment.RemovePackage(0);
                Assert.True(result);
                Assert.DoesNotContain(package, shipment.Packages);
            }
        }

        [Fact]
        public void TotalCostByPackageNameTests()
        {
            var shipment = new Shipment()
            {
                Name = "Test Shipment",
                Description = "This is a test shipment",
            };

            Assert.Empty(shipment.Packages);
            shipment.Packages.AddRange(_packages);

            var result = shipment.TotalCostByPackageName();

            Assert.Equal(5, result.Count);
            Assert.Contains(result, r => r.Item1 == "Box A" && r.Item2 == 20m);
            Assert.Contains(result, r => r.Item1 == "Box B" && r.Item2 == 10m);
            Assert.Contains(result, r => r.Item1 == "Box C" && r.Item2 == 60m);
            Assert.Contains(result, r => r.Item1 == "Box D" && r.Item2 == 10m);
            Assert.Contains(result, r => r.Item1 == "Box E" && r.Item2 == 20m);
        }

        [Fact]
        public void SizeCategoriesTests()
        {
            var shipment = new Shipment()
            {
                Name = "Test Shipment",
                Description = "This is a test shipment",
            };

            Assert.Empty(shipment.Packages);
            shipment.Packages.AddRange(_packages);

            var result = shipment.SizeCategories();

            Assert.Equal(3, result.Count);
            Assert.Contains(result, r => r.Item1 == PackageCategory.Small.ToString() && r.Item2 == 20m);
            Assert.Contains(result, r => r.Item1 == PackageCategory.Medium.ToString() && r.Item2 == 30m);
            Assert.Contains(result, r => r.Item1 == PackageCategory.Large.ToString() && r.Item2 == 70m);
        }

        [Fact]
        public void ShipmentWeightTests()
        {
            var shipment = new Shipment()
            {
                Name = "Test Shipment",
                Description = "This is a test shipment",
            };

            Assert.Empty(shipment.Packages);
            shipment.Packages.AddRange(_packages);

            //yes, we could get the weight with "weight = _package.Sum(p => p.Weight);" but that is how the shipment does it.
            var weight = 0m;
            foreach (var package in _packages)
            {
                weight += package.Weight;
            }

            Assert.Equal(weight, shipment.Weight);
        }
    }
}
