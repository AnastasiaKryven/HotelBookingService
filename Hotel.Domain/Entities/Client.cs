namespace Hotel.Domain.Entities
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string BirthDay { get; set; }

        public string NumberPhone { get; set; }

        public string Country { get; set; }
    }
}
