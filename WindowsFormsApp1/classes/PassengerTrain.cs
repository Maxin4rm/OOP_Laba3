using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.classes.FreightTrain;
using static WindowsFormsApp1.classes.PassengerTrain;

namespace WindowsFormsApp1.classes
{
    public class PassengerTrain : Train
    {
        [Flags]
        public enum DistanceType { Suburban, Local, LongDistance };
        [Name("Distance Type")]
        public DistanceType distanceType;
        [Name("Max Capacity")]
        public int maxCapacity;

        public PassengerTrain() { }

        public PassengerTrain(DistanceType _distanceType, int _maxCapacity, int _amountOfWagons, int _tractionForce, int _brakingDistance, string _model, int _maxSpeed, Person _driver) :
                      base(_amountOfWagons, _tractionForce, _brakingDistance, _model, _maxSpeed, _driver)
        {
            this.distanceType = _distanceType;
            this.maxCapacity = _maxCapacity;
        }

    }
}
