using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.classes
{
    public abstract class Train : Transport
    {
        [Name("Amount Of Wagons")]
        public int amountOfWagons;
        [Name("Traction Force")]
        public int tractionForce;
        [Name("Braking Distance")]
        public int brakingDistance;

        public Train() { }

        public Train(int _amountOfWagons, int _tractionForce, int _brakingDistance, string _model, int _maxSpeed, Person _driver) : base(_model, _maxSpeed, _driver)
        {
            this.amountOfWagons = _amountOfWagons;
            this.tractionForce = _tractionForce;
            this.brakingDistance = _brakingDistance;
        }
    }
}
