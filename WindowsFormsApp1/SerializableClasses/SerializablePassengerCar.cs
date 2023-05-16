using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.SerializableClasses;
using static WindowsFormsApp1.classes.PassengerTrain;

namespace WindowsFormsApp1.SerializableClasses
{
	[Serializable]
	public class SerializablePassengerCar : SerializableTransport
	{
		public enum BodyShape { InCorrect, Hatchback, Pickup, Limousine, Coupe, Sedan, Minivan };
		public BodyShape bodyShape = BodyShape.InCorrect;		
		public int numberOfSeats = -1;
		public int horsePower = -1;
		public int numberOfWheels = -1;
		public int torgue = -1;
		public SerializablePassengerCar() { }

		public SerializablePassengerCar(string _model, int _maxSpeed, SerializablePerson _driver, BodyShape _bodyShape, int _numberOfSeats, int _horsePower, int _numberOfWheels, int _torgue) :
					  base(_model, _maxSpeed, _driver)
		{
			this.bodyShape = _bodyShape;
			this.numberOfSeats = _numberOfSeats;
			this.horsePower = _horsePower;
			this.numberOfWheels = _numberOfWheels;
			this.torgue = _torgue;
		}
	}
}
