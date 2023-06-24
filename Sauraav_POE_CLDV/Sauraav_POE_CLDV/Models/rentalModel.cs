namespace Sauraav_POE_CLDV.Models
{
    public class rentalModel
    {
        public int rentalID { get; set; }
        public string carNo { get; set; }
        public string inspectorNo { get; set; }
        public int driver { get; set; }
        public double rentalFee { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

    }
}