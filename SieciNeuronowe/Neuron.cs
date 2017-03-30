using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe
{
    class Neuron
    {
        public double[] _weights { get; set; }

        public Neuron(int size)
        {
            _weights = new double[size];
        }

        public double Sgn(double y)
        {
            if (y < 0)
                return -1;
            else
                return 1;
        }

        public double Y(double[] X)
        {
            double result = 0;
            for (int i = 0; i < X.Length; i++)
            {
                result += _weights[i] * X[i];
            }
            return result;
        }
    }

}
