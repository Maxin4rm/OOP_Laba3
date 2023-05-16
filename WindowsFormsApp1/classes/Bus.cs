using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.classes
{
    public class Bus : Car
    {
        [Name("Max Capacity")]
        public int maxCapacity;
        [Name("Has Air Conditioning")]
        public bool hasAirConditioning;
        
        public enum BusType { Passenger, Special };
        [Name("Bus type")]
        public BusType type;

        public Bus() { }

        public Bus(int _maxCapacity, bool _hasAirConditioning, BusType _type, int _horsePower, int _numberOfWheels, int _torgue, string _model, int _maxSpeed, Person _driver) :
                      base(_horsePower, _numberOfWheels, _torgue, _model, _maxSpeed, _driver)
        {
            this.maxCapacity = _maxCapacity;
            this.hasAirConditioning = _hasAirConditioning;
            this.type = _type;
        }
    }
}
