namespace ConsoleApp2.Models
{
    public class Journal
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Classifications BrandA { get; set; }
        public Classifications BrandB { get; set; }
    }
}
