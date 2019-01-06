using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farm_ASPCore_Webapi.Models
{
    public class Stable
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
    }
}
