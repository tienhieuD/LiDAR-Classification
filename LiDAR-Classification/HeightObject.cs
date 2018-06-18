using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiDAR_Classification
{
    class HeightObject
    {
        public float Value;
        public int Cluster;

        public HeightObject(float value, int cluster=-1)
        {
            this.Value = value;
            this.Cluster = cluster;
        }

        public float GetDistance(HeightObject that)
        {
            return Math.Abs(this.Value - that.Value);
        }
    }
}
