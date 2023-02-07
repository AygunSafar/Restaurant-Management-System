using ManagementSystem.DAL;
using ManagementSystem.Models;

namespace ManagementSystem.ViewModels
{
    public class HomeVM
    {

    
        public Kassa Kassa { get; set; }
        public Reservation Reservation { get; set; }

        //public int CaloriesBurnedLast7Days
        //{
        //    get
        //    {
        //        using (var db = new FitnessTrackerWebAPIContext())
        //        {
        //            int calsLast7Days = 0;
        //            calsLast7Days = db.Workouts.Where(w => w.Date <= DateTime.Now.AddDays(-7) && w.UserID == ID).Sum(w => w.CaloriesBurned);
        //            return calsLast7Days;
        //        }
        //    }


        //}

    }
}
