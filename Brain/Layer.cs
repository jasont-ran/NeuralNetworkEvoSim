using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Brain
{

    //http://neuralnetworksanddeeplearning.com/about.html
    public class Layer
    {
        public List<Neuron> Neurons { get; set; } = new List<Neuron>();
    }
}
