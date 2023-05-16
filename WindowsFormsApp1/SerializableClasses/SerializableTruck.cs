using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;

namespace WindowsFormsApp1.SerializableClasses
{
    [Serializable]
    public class SerializableTruck : SerializableTransport
    {
        public int maxWeight = -1;        
        public bool hasTrailer = false;       
        public int horsePower = -1;        
        public int numberOfWheels = -1;
        public int torgue = -1;

        public SerializableTruck() { }

        public SerializableTruck(string _model, int _maxSpeed, SerializablePerson _driver, int _maxWeight, bool _hasTrailer, int _horsePower, int _numberOfWheels, int _torgue) :
                      base(_model, _maxSpeed, _driver)
        {
            this.maxWeight = _maxWeight;
            this.hasTrailer = _hasTrailer;
            this.horsePower = _horsePower;
            this.numberOfWheels = _numberOfWheels;
            this.torgue = _torgue;
        }
    }
}