using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;

namespace WindowsFormsApp1.SerializableClasses
{
    [Serializable]
    public class SerializableFreightTrain : SerializableTransport
    {
        public int maxWeight = -1;
        public enum WagonType { InCorrect, Tank, Hopper, Boxcar, GondolaCar };
        public WagonType wagonType = WagonType.InCorrect;
        public int amountOfWagons = -1;
        public int tractionForce = -1;
        public int brakingDistance = -1;
        public SerializableFreightTrain() { }

        public SerializableFreightTrain(string _model, int _maxSpeed, SerializablePerson _driver, int _maxWeight, WagonType _wagonType, int _amountOfWagons, int _tractionForce, int _brakingDistance) :
                      base(_model, _maxSpeed, _driver)
        {
            this.maxWeight = _maxWeight;
            this.wagonType = _wagonType;
            this.amountOfWagons = _amountOfWagons;
            this.tractionForce = _tractionForce;
            this.brakingDistance = _brakingDistance;
        }

    }
}
