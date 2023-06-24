namespace Sauraav_POE_CLDV.Models
{
    public class returnTableModel
    {
        public int returnID { get; set; }
        public int rentalID { get; set; }
        public string inspectorNo { get; set; }
        public DateTime dateReturn { get; set; }
        public int daysElapsed { get; set; }
        public double fineValue { get; set; }
    }
}
