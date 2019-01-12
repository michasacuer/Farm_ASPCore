using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Farm_ASPCore_Webapi.Models.Interfaces
{   
    public abstract class WorkStrategy
    {
        public abstract double TimeOfWork(double hours);
    }
}
