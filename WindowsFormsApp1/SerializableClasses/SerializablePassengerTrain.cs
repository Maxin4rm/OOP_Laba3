using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.SerializableClasses
{

    [Serializable]
    public class SerializablePassengerTrain : SerializableTransport
    {
        public enum DistanceType { InCorrect, Suburban, Local, LongDistance };
        public DistanceType distanceType = DistanceType.InCorrect;
        public int maxCapacity = -1;
        public int amountOfWagons = -1;
        public int tractionForce = -1;
        public int brakingDistance = -1;
        public SerializablePassengerTrain() { }

        public SerializablePassengerTrain(string _model, int _maxSpeed, SerializablePerson _driver, DistanceType _distanceType, int _maxCapacity, int _amountOfWagons, int _tractionForce, int _brakingDistance) :
                      base(_model, _maxSpeed, _driver)
        {
            this.distanceType = _distanceType;
            this.maxCapacity = _maxCapacity;
            this.amountOfWagons = _amountOfWagons;
            this.tractionForce = _tractionForce;
            this.brakingDistance = _brakingDistance;
        }

    }
}
