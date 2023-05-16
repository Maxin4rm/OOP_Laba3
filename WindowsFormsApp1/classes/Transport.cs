using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.classes
{
    public abstract class Transport
    {
        
        [Name("Model")]
        public string model;
        [Name("Max speed")]
        public int maxSpeed;
        public Person driver;

        public Transport() { }
        public Transport(string _model, int _maxSpeed, Person _driver)
        {
            this.model = _model;
            this.maxSpeed = _maxSpeed;
            this.driver = _driver;
        }

        public string Model
        {
            get => model;
        }

        public int MaxSpeed
        {
            get => maxSpeed;
        }
    }
}
