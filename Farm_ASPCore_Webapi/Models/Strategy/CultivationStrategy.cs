using Farm_ASPCore_Webapi.Models.Interfaces;

namespace Farm_ASPCore_Webapi.Models
{
    public class CultivationStrategy : WorkStrategy
    {
        public override double TimeOfWork(double hours) => hours * hours - refuelTime;

        private double refuelTime = 10;
    }
}
