namespace LusionTech_CRM_API.DTOs
{
    public class BidDTO
    {
        public string Link { get; set; }
        public Guid AccountID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateTime { get; set; }
    }
}
