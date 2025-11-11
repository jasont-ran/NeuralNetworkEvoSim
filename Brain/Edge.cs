using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Brain
{
    public class Edge
    {
        public int Weight { get; set; }
        public Neuron? FromNeuron { get; set; }
        public Neuron? ToNeuron { get; set; } 
        }
    }
}
