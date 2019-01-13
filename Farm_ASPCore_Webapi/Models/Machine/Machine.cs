using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Farm_ASPCore_Webapi.Models.Enums;
using Farm_ASPCore_Webapi.Models.Interfaces;

namespace Farm_ASPCore_Webapi.Models
{
    public class Machine : ISummary
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        public Farm Farm  { get; set; }

        public double   HoursPerDay    { get; set; }
        public int      DaysOfWork     { get; set; }
        public Strategy MappedStrategy { get; set; }
 
        [NotMapped]
        public WorkStrategy Strategy { get; set; }

        public double GetManHours() => DaysOfWork * Strategy.TimeOfWork(HoursPerDay);
        public double GetCost()     => GetManHours() * 100;
    }
}
