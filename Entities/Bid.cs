namespace LusionTech_CRM_API.Entities
{
    public class Bid
    {
        public int BidId { get; set; }
        public string Link { get; set; }
        public Guid AccountID { get; set; }
        public Account Account { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }
    }
}
