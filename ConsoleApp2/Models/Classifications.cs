namespace ConsoleApp2.Models
{
    //[Microsoft.EntityFrameworkCore.Owned]
    public class Classifications
    {
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public decimal Qty { get; set; }
    }
}
