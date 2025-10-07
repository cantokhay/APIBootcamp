namespace APIBootcamp.UI.Models
{
    public class RevenueChartViewModel
    {
        public List<string> Labels { get; set; } = new();
        public List<int> Income { get; set; } = new();
        public List<int> Expense { get; set; } = new();

        public int ApprovedResevation { get; set; }
        public int CancelledReservation { get; set; }
        public int PendingReservation { get; set; }
    }
}
