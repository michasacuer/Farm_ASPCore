using Farm_ASPCore_Webapi.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_ASPCore_Webapi.Models
{
    public abstract class Worker
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int  FarmId { get; set; }
        public Farm Farm   { get; set; }

        public string           FirstName       { get; set; }
        public string           LastName        { get; set; }
        public DateTime         StartOfContract { get; set; }
        public DateTime         EndOfContract   { get; set; }
        public virtual  double  UsdPerHour      { get; set; }
        public virtual  int     HoursPerDay     { get; set; }
        public virtual  int     DaysOfWork      { get; set; }
        public virtual  double  BaseSalary      { get; set; }
        public abstract double  Salary          { get; set; }

        public virtual double CountBaseSalary() => throw new NotImplementedException();
    }
}
