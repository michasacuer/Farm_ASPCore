﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public interface ICultivation
    {
        //[Key]
        //public int Id { get; set; }

        //[ForeignKey("Farm")]
        //public int FarmId { get; set; }
        //public Farm Farm { get; set; }

        void Sow();
        void Plow();
        void Harvest();
        void Add();
    }
}
