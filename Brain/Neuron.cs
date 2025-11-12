using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Brain
{
    public class Neuron
    {
        public int Id { get; set; }
        public double Bias { get; set; }
        public double InputValue { get; set; }
        public Edge[] Edges { get; set; }
    }
}
