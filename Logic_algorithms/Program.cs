using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a new object from shift class and call check_active_shift method
            Shift newShift = new Shift(DateTime.Parse("09:00 AM"),DateTime.Parse("06:30 PM"),DateTime.Now);
            bool isActiveShift = newShift.check_active_shift();
            Console.WriteLine("Is an active shift: " + isActiveShift);
            Console.WriteLine("shift start at: "+ newShift.shift_start.ToString("hh:mm tt"));
            Console.WriteLine("shift end at: " + newShift.end.ToString("hh:mm tt"));
            Console.WriteLine("current time: "+ newShift.current_time.ToString("hh:mm tt"));
            Console.ReadLine();
        }
    }

    //Shift class
    public class Shift{
        public DateTime shift_start;
        public DateTime end;
        public DateTime current_time;
        bool in_shift;

        public Shift(DateTime shift_start, DateTime end, DateTime current_time)
        {
            this.shift_start = shift_start;
            this.end = end;
            this.current_time = current_time;
        }

        //check_active_shift method using Timespan compare , if shift_start <= current_time <= end is true then it is an active shift.
        public bool check_active_shift()
        {
            if((TimeSpan.Compare(shift_start.TimeOfDay, current_time.TimeOfDay) == -1 || TimeSpan.Compare(shift_start.TimeOfDay, current_time.TimeOfDay) == 0) && (TimeSpan.Compare(current_time.TimeOfDay, end.TimeOfDay) == -1 || TimeSpan.Compare(current_time.TimeOfDay, end.TimeOfDay) == 0))
            {
                in_shift = true;
                return true;
            }
            else
                return false;
        }
    }
}
