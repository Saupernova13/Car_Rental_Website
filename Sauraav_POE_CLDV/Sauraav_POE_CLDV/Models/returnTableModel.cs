//Sauraav Jayrajh
//ST100024620
using Microsoft.AspNetCore.Mvc;

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

        public double calculatePenaltyFeeLogic()
        {
            const double penaltyFee = 500.00;
            double amountDue = 0;
            if (daysElapsed > 0)
            {
                amountDue = daysElapsed * penaltyFee;
            }
            return (amountDue);
        }
    }
}
