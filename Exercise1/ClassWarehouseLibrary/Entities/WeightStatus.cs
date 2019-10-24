using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWarehouseLibrary.Entities
{
    public class WeightStatus : ClassWarehouseLibrary.Status
    {
        public double Mass { get; set; }

        //public WeightStatus()
        //{
        //    base.
        //}

        public override bool Equals(object obj)
        {
            return obj is WeightStatus status &&
                   base.Equals(obj) &&
                   Mass == status.Mass;
        }

        public override int GetHashCode()
        {
            int hashCode = 1804219783;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Mass.GetHashCode();
            return hashCode;
        }
    }
}
