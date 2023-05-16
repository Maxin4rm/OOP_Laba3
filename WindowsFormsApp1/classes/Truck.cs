using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp1.classes.PassengerCar;

namespace WindowsFormsApp1.classes
{
    public class Truck : Car
    {
        [Name("Max Weight")]
        public int maxWeight;
        [Name("Has Trailer")]
        public bool hasTrailer;

        public Truck() { }

        public Truck(int _maxWeight, bool _hasTrailer, int _horsePower, int _numberOfWheels, int _torgue/*, Color _color*/, string _model, int _maxSpeed, Person _driver) :
                      base(_horsePower, _numberOfWheels, _torgue/*, _color*/, _model, _maxSpeed, _driver)
        {
            this.maxWeight = _maxWeight;
            this.hasTrailer = _hasTrailer;
        }
    }
}
