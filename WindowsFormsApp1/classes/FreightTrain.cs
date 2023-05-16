using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.classes
{
    public class FreightTrain : Train
    {
        [Name("Max Weight")]
        public int maxWeight;
        
        [Flags]
        public enum WagonType { Tank, Hopper, Boxcar, GondolaCar };
        [Name("Wagon Type")]
        public WagonType wagonType;

        public FreightTrain() { }

        public FreightTrain(int _maxWeight, WagonType _wagonType, int _amountOfWagons, int _tractionForce, int _brakingDistance, string _model, int _maxSpeed, Person _driver) :
                      base(_amountOfWagons, _tractionForce, _brakingDistance, _model, _maxSpeed, _driver)
        {
            this.maxWeight = _maxWeight;
            this.wagonType = _wagonType;
        }

    }
}
