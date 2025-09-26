namespace Packages
{
    public class CalculateCosts : ICalculateCosts
    {
        public decimal CalculatePackageCost(IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package), "Package cannot be null");
            }

            var volume = package.Length * package.Width * package.Height;

            //this should be in a database or config file
            if (volume < 100000)
                return 10.00m;
            if (volume < 500000)
                return 20.00m;

            return 30.00m;
        }
    }
}
