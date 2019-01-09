namespace Farm_ASPCore_Webapi.Models.Bonus
{
    public abstract class Bonus : Worker
    {
        public Bonus(Worker worker) => this.worker = worker;
        protected Worker worker { get; private set; }

        //tutaj musi byc wszystko z workera, worker nie ma np FirstName
    }
}
