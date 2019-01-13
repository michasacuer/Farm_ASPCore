using Farm_ASPCore_Webapi.Models.Interfaces;

namespace Farm_ASPCore_Webapi.Models
{
    public class FarmStrategy : WorkStrategy
    {
        public override double TimeOfWork(double hours) => hours * hours - serviceTime;

        private int serviceTime = 2;
    }
}
