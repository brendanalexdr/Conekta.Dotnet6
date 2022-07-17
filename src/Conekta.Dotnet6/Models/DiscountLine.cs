namespace ConektaDotnet6.Models
{
    public class DiscountLine
    {
        public string id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public string parent_id { get; set; }
    }
}