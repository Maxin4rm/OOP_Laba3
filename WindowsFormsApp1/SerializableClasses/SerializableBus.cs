using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.classes.Bus;

namespace WindowsFormsApp1.SerializableClasses
{
    [Serializable]
    public class SerializableBus : SerializableTransport
    {
        public int maxCapacity = -1;
        public bool hasAirConditioning = false;
        public enum BusType { InCorrect, Passenger, Special };
        public BusType type = BusType.InCorrect;
        public int horsePower = -1;
        public int numberOfWheels = -1;
        public int torgue = -1;
        public SerializableBus() { }

        public SerializableBus(string _model, int _maxSpeed, SerializablePerson _driver, int _maxCapacity, bool _hasAirConditioning, BusType _type, int _horsePower, int _numberOfWheels, int _torgue) :
                      base(_model, _maxSpeed, _driver)
        {
            this.maxCapacity = _maxCapacity;
            this.hasAirConditioning = _hasAirConditioning;
            this.type = _type;
            this.horsePower = _horsePower;
            this.numberOfWheels = _numberOfWheels;
            this.torgue = _torgue;
        }
    }
}
