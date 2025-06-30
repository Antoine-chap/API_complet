namespace WebApplication1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string Email { get; set; } = string.Empty;

        //Propriété de navigation pour la relation 1-à-plusieurs
        public virtual ICollection<Address> ListAddresses { get; set; } = new List<Address>();
    }
}
