using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.classes
{
    public abstract class Car : Transport
    {
        [Name("Horse Power")]
        public int horsePower;
        [Name("Number Of Wheels")]
        public int numberOfWheels;
        [Name("Torgue")]
        public int torgue;
        /*[Name("Color")]
        public Color color;*/

        public Car() { }

        public Car(int _horsePower, int _numberOfWheels, int _torgue, string _model, int _maxSpeed, Person _driver) :
                      base(_model, _maxSpeed, _driver)
        {
            this.horsePower = _horsePower;
            this.numberOfWheels = _numberOfWheels;
            this.torgue = _torgue;
        }
    }
}
