using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Farm_ASPCore_Webapi.Models
{
    public class MachineObjectPool
    {
        public static MachineObjectPool Instance { get; } = new MachineObjectPool();
        public static readonly int MaxPoolSize = 5;
        public bool IsPoolPopulated()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                return false;
            }
            else
                return true;
        }

        public List<Machine> PopulatePool(DbSet<Machine> machines) => pool = machines.ToList();

        public Machine AcquireMachine()
        {
            if (pool.Count <= 0) throw new Exception("Pool empty");
            Machine reusable = pool.First();
            pool.Remove(pool.First());
            return reusable;
        }

        public void ReleaseMachine(Machine reusable)
        {
            if (pool.Count >= MaxPoolSize) throw new Exception("Pool full, PANIC");
            pool.Add(reusable);
        }

        private MachineObjectPool() { }

        private volatile List<Machine> pool = new List<Machine>(MaxPoolSize);
        private bool isInitialized = false;
    }
}
