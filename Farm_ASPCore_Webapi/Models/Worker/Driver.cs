using System;

namespace Farm_ASPCore_Webapi.Models
{
    public class Driver : Worker
    {
        public float UsdPerHour = 10;
        public int HoursPerDay = 7;
        public int DaysOfWork = 18;

        public override float CountSalary()
        {
            throw new NotImplementedException();
        }
    }
}
