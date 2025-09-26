namespace Packages
{
    public interface IShipment
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<IPackage> Packages { get; set; }
        decimal Weight { get; }
        public List<(string, decimal)> SizeCategories();
        public List<(string, decimal)> TotalCostByPackageName();
        public void AddPackage(IPackage package);
        public bool RemovePackage(int index);
    }
}
