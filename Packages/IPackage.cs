namespace Packages
{
    public interface IPackage
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Weight { get; set; }
        decimal Length { get; set; }
        decimal Width { get; set; }
        decimal Height { get; set; }
    }
}
