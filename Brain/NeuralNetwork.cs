using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation.Brain
{
    public class NeuralNetwork
    {
        //ADD RANDOM GENERATOR FOR INITIAL WEIGHTS AND BIASES
        private readonly Random random = new Random();
        private List<Layer> layers;
        private int NeuronId = 1;

        public NeuralNetwork()
        {
            //layers = new List<Layer>();

            //int amountOfLayers = 4;
            //int inputLayerNeurons = 4;
            //int hiddenLayerNeurons = 4;
            //int outputLayerNeurons = 2;
            layers = new List<Layer>()
            {
                new Layer{ Neurons = { new Neuron { }, new Neuron { }, new Neuron { }, new Neuron { } } },
                new Layer{ Neurons = { new Neuron { }, new Neuron { }, new Neuron { }, new Neuron { } } },
                new Layer{ Neurons = { new Neuron { }, new Neuron { }, new Neuron { }, new Neuron { } } },
                new Layer{ Neurons = { new Neuron { }, new Neuron { }, new Neuron { }, new Neuron { } } }
            };
            InitializeNetwork(layers);
        }

        private void InitializeNetwork(List<Layer> layers)
        {
            for(int layerIndex = 0; layerIndex < layers.Count - 1; layerIndex++)
            {
                for(int neuronIndex = 0; neuronIndex < layers[layerIndex].Neurons.Count; neuronIndex++)
                {
                    layers[layerIndex].Neurons[neuronIndex].Id = NeuronId++;
                    layers[layerIndex].Neurons[neuronIndex].Bias = random.NextDouble() * 10;
                    layers[layerIndex].Neurons[neuronIndex].Edges = new Edge[layers[layerIndex + 1].Neurons.Count];

                    for (int nextLayerNeuronIndex = 0; nextLayerNeuronIndex < layers[layerIndex + 1].Neurons.Count(); nextLayerNeuronIndex++)
                    {
                        layers[layerIndex].Neurons[neuronIndex].Edges[nextLayerNeuronIndex] = new Edge
                        {
                            FromNeuron = layers[layerIndex].Neurons[neuronIndex],
                            ToNeuron = layers[layerIndex + 1].Neurons[nextLayerNeuronIndex],
                            Weight = random.Next(0, 10)
                        };
                    }
                }
            }
        }

        public void ForwardPropagation()
        {

        }
        public void BackwardsPropagation()
        {

        }
    }
}
