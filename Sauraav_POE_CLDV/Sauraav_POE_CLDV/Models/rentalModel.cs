namespace Sauraav_POE_CLDV.Models
{
    public class rentalModel
    {
        public int rentalID { get; set; }
        public int returnID { get; set; }
        public string inspectorNo { get; set; }
        public string dateReturn { get; set; }
        public int daysElapsed { get; set; }
        public double fineValue { get; set; }
    }
}
