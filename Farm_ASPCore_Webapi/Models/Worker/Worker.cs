using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_ASPCore_Webapi.Models
{
    public abstract class Worker
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Farm")]
        //public int FarmId { get; set; }
        //public Farm Farm { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartOfContract { get; set; }
        public DateTime EndOfContract { get; set; }
        public float UsdPerHour { get; set; }
        public int HoursPerDay { get; set; }
        public int DaysOfWork { get; set; }

        public abstract float CountSalary();
    }
}
