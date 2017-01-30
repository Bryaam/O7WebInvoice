// Create by Felix A. Bueno


namespace Angkor.O7Web.Common.Advisory.Entity
{
    public class Activity 
    {
        public string Title { get; set; }
        public string Date { get; set; }
    }

    public class ActivityReport : Activity
    {
        public string WorkerId { get; set; }
        public string Worker { get; set; }
        public string CenterCostId { get; set; }
        public string CenterCost { get; set; }
        public string Period { get; set; }
    }
}