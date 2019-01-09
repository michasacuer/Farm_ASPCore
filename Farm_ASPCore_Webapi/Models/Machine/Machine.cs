﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Farm_ASPCore_Webapi.Models.Interfaces;

namespace Farm_ASPCore_Webapi.Models
{
    public class Machine
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        public Farm Farm  { get; set; }

        public int HoursPerDay { get; set; }
        public int DaysOfWork  { get; set; }

        [NotMapped]
        public IWorkStrategy Strategy { get; set; }

        public double GetManHours() => DaysOfWork * Strategy.TimeOfWork(HoursPerDay);
    }
}
