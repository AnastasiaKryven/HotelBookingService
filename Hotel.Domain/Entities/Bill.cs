namespace Hotel.Domain.Entities
{
    public class Bill
    {
        public int BillId { get; set; }

        public Client ClientId { get; set; }

        public float RezultSum { get; set; }

        public bool IsPaid { get; set; }
    }
}
