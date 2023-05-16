using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;
using static WindowsFormsApp1.classes.PassengerTrain;

namespace WindowsFormsApp1.Factories
{
    class PassengerTrainFactory : TransportFactory
    {
        public override Transport createTransport(List<string> fields)
        {
            Person.Sex sex = (Person.Sex)Enum.Parse(typeof(Person.Sex), fields[9]);
            Person person = new Person(fields[7], fields[8], sex, Int32.Parse(fields[10]));
            return new PassengerTrain(           
                (PassengerTrain.DistanceType)Enum.Parse(typeof(PassengerTrain.DistanceType), fields[0]),
                Int32.Parse(fields[1]),
                Int32.Parse(fields[2]),
                Int32.Parse(fields[3]),
                Int32.Parse(fields[4]),
                fields[5],
                Int32.Parse(fields[6]),
                person);
        }
    }
}
