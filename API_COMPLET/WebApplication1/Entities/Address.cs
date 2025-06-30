namespace WebApplication1.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StreetNumber { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public string Town { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public virtual User User { get; set; } = null!;
    }
}
