using System;
using System.Collections.Generic;
using System.Linq;

namespace Farm_ASPCore_Webapi.Models
{
    public class MachineObjectPool
    {
        public static MachineObjectPool Instance { get; } = new MachineObjectPool();

        public Machine AcquireMachine()
        {
            if (pool.Count <= 0) throw new Exception("Pool empty");
            Machine reusable = pool.First();
            pool.Remove(pool.First());
            return reusable;
        }

        public void ReleaseMachine(Machine reusable)
        {
            if (pool.Count >= maxPoolSize) throw new Exception("Pool full, PANIC");
            pool.Add(reusable);
        }

        private MachineObjectPool()
        {
            pool = MachineHelper.GetPool(maxPoolSize);
        }

        private volatile List<Machine> pool;
        private readonly int maxPoolSize = 10;
    }
}
