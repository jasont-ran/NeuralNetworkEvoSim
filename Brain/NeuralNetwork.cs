using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        public float[] EntityThink(float[] inputs)
        {
            SetInputLayerValues(inputs);
            ForwardPropagation();


            return new float[] { 0f, 0f };
            
        }

        private void SetInputLayerValues(float[] inputs)
        {
            if(inputs.Length != layers[0].Neurons.Count)
            {
                throw new ArgumentException("Input length does not match number of input neurons nodes.");
            }

            for (int i = 0; i < layers[0].Neurons.Count; i++)
            {
                layers[0].Neurons[i].InputValue = inputs[i];
            }
        }

        private void ForwardPropagation()
        {
            for(int layerIndex = 0; layerIndex < layers.Count - 2; layerIndex++)
            {
                int nextLayerNeuronIndex = 0;
                for (int curNeuronIndex = 0; curNeuronIndex < layers[layerIndex].Neurons.Count; curNeuronIndex++)
                {
                    var result = 0.0;
                    foreach(var neuron in layers[layerIndex].Neurons)
                    {
                        result += neuron.Edges[nextLayerNeuronIndex].Weight * neuron.InputValue;
                    }
                    result += layers[layerIndex + 1].Neurons[nextLayerNeuronIndex].Bias;
                    nextLayerNeuronIndex++;
                }
                if (layerIndex > 0) { ReluActivation(layers[layerIndex]); }
            }
        }

        private void ReluActivation(Layer layer)
        {
            foreach(var neuron in layer.Neurons)
            {
                if(neuron.InputValue < 0)
                {
                    neuron.InputValue = 0;
                }
            }
        }

        private float[] OutputValues()
        {
            return new float[] { 0f, 0f };
        }

        private void BackwardsPropagation()
        {

        }
    }
}
