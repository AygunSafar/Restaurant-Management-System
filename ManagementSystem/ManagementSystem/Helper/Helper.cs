using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ManagementSystem.Helper
{
    public static class Helper
    {

        public enum Gender
        {
            [Display(Name = "Qadın")]
            Qadın = 1,
            [Display(Name = "Kişi")]
            Kişi= 2
        }
        public enum ReservationStatus
        {
            Pending,
            Cancelled,
            Done
        }

        
    }
}
