namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;
        protected Worker worker { get; private set; }
    }
}
