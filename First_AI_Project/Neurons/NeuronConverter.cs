using System;
using System.Collections.Generic;
using System.Text;

namespace First_AI_Project.Neurons
{
    public class NeuronConverter
    {
        private decimal _weight = 0.5m;
        public decimal LastError { get; private set; }
        public decimal Smoothing { get; set; } = 0.00001m;

        public decimal ProcessInputData(decimal input)
        {
            return input * _weight;
        }

        public decimal RestoreInputData(decimal output)
        {
            return output / _weight;
        }

        public void Train(decimal input, decimal expectedResult)
        {
            var actualResult = input * _weight;
            LastError = expectedResult - actualResult;
            var correction = (LastError / actualResult) * Smoothing;
            _weight += correction;
        }

    }
}
