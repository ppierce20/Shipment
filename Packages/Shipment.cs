namespace Packages
{
    public class Shipment : IShipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IPackage> Packages { get; set; }
        public decimal Weight => Packages.Sum(p => p.Weight);

        public Shipment()
        {
            Packages = new List<IPackage>();
            Name = string.Empty;
            Description = string.Empty;
        }

        public List<(string, decimal)> SizeCategories()
        {
            var result = new List<(string, decimal)>();
            var total = 0m;
            foreach (var category in Enum.GetValues(typeof(PackageCategory)))
            {
                total = 0m;
                foreach (var ipackage in Packages.Where(p => (p as Package)?.Category == (PackageCategory)category))
                {
                    var package = ipackage as Package;
                    total += package?.Cost ?? 0m;
                }
                result.Add((category?.ToString() ?? string.Empty, total));
            }

            return result;
        }

        public List<(string, decimal)> TotalCostByPackageName()
        {
            var result = new List<(string, decimal)>();
            foreach (var packageGroup in Packages.GroupBy(p => p.Name))
            {
                var totalCost = 0m;
                foreach (var ipackage in packageGroup)
                {
                    var pacakge = ipackage as Package;
                    totalCost += pacakge?.Cost ?? 0m;
                }

                result.Add((packageGroup.Key, totalCost));
            }

            return result;
        }

        public void AddPackage(IPackage package)
        {
            Packages.Add(package);
        }

        public bool RemovePackage(int index)
        {
            if (index < 0 || index >= Packages.Count)
            {
                return false;
            }

            Packages.RemoveAt(index);
            return true;
        }
    }
}
