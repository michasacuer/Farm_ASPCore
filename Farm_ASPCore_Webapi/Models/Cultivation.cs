using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farm_ASPCore_Webapi.Models
{
    public class Cultivation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
    }
}
