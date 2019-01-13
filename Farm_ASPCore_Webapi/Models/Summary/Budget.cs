using System.ComponentModel.DataAnnotations;

namespace Farm_ASPCore_Webapi.Models
{
    public class Budget
    {
        [Key]
        public int    Id    { get => 1; set { } } 
        public double Value { get; set; }

        public static Budget GetBudget() => budget;

        private static Budget budget = new Budget();
    }
}
