using System;

namespace Farm_ASPCore_Webapi.Models
{
    public class Summary
    {
        public static Summary Instance { get; } = new Summary();

        public double   Budget           { get; set; }
        public double   MachinesCost     { get; set; }
        public double   WorkersCost      { get; set; }
        public double   AnimalsCost      { get; set; }
        public double   CultivationsCost { get; set; }
        public double   SummaryCost      { get; set; }
        public DateTime SummaryDate      { get; set; }

        public void GetSummary(Farm farm)
        {
            foreach (Worker worker in farm.Workers)
                WorkersCost -= worker.GetCost();

            AnimalsCost = Animals.GetAnimalsCost();

            foreach (Machine machine in farm.Machines)
                MachinesCost -= machine.GetCost();

            SummaryCost = Budget - ( AnimalsCost + WorkersCost + MachinesCost);
        }

        //Originator
        public void SetState(Summary state)              => this.state = state;
        public Summary GetState()                        => state;
        public Memento Save()                            => new Memento(state, ++indexer);
        public void GetStateFromMemento(Memento memento) => state = memento.GetState();

        private Summary state;
        private int indexer = -1;

    }
}
