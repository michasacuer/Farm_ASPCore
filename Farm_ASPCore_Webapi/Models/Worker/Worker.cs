using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Farm_ASPCore_Webapi.Models.Enums;
using Farm_ASPCore_Webapi.Models.Interfaces;

namespace Farm_ASPCore_Webapi.Models
{
    public abstract class Worker : ISummary
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int  FarmId { get; set; }
        public Farm Farm   { get; set; }

        public virtual  Job      Kind            { get; set; }
        public virtual  string   FirstName       { get; set; }
        public virtual  string   LastName        { get; set; }
        public virtual  double   UsdPerHour      { get; set; }
        public virtual  int      HoursPerDay     { get; set; }
        public virtual  int      DaysOfWork      { get; set; }
        public virtual  double   BaseSalary      { get; set; }
        public abstract double   Salary          { get; set; }
        public abstract double   GetTaxes();

        public double CountBaseSalary() => Math.Round(BaseSalary = Salary = UsdPerHour * HoursPerDay * DaysOfWork - GetTaxes(), 2);
        public double GetCost() => Salary;
    }
}
