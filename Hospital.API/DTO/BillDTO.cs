namespace Hospital.API.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public string PatientName { get; set; }
        public decimal Amount { get; set; }
    }
}
