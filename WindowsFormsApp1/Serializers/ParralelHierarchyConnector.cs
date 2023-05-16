using WindowsFormsApp1.SerializableClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;
using System.Reflection;

namespace WindowsFormsApp1.Serializers
{
    public static class ParralelHierarchyConnector
    {
        public static SerializablePerson DriverToPDriver(Person driver)
        {
            return new SerializablePerson(driver.firstname, driver.lastname, (SerializablePerson.Sex)(driver.sex + 1), driver.age);
        }

        public static Person PDriverToDriver(SerializablePerson driver)
        {
            return new Person(driver.firstname, driver.lastname, (Person.Sex)(driver.sex - 1), driver.age);
        }
        
        public static List<SerializableTransport> TransportsToPTransports(List<Transport> transports)
        {
            List<SerializableTransport> models = new List<SerializableTransport>();
            foreach (var transport in transports)
            {
                switch (transport)
                {
                    case Bus _:
                        var busModel = (Bus)transport;
                        models.Add(new SerializableBus(busModel.model, busModel.maxSpeed, DriverToPDriver(busModel.driver), busModel.maxCapacity, busModel.hasAirConditioning, (SerializableBus.BusType)(busModel.type + 1), busModel.horsePower, busModel.numberOfWheels, busModel.torgue));
                        break;
                    case Truck _:
                        var truckModel = (Truck)transport;
                        models.Add(new SerializableTruck(truckModel.model, truckModel.maxSpeed, DriverToPDriver(truckModel.driver), truckModel.maxWeight, truckModel.hasTrailer, truckModel.horsePower, truckModel.numberOfWheels, truckModel.torgue));
                        break;
                    case PassengerCar _:
                        var passengerCarModel = (PassengerCar)transport;
                        models.Add(new SerializablePassengerCar(passengerCarModel.model, passengerCarModel.maxSpeed, DriverToPDriver(passengerCarModel.driver), (SerializablePassengerCar.BodyShape)(passengerCarModel.bodyShape + 1), passengerCarModel.numberOfSeats, passengerCarModel.horsePower, passengerCarModel.numberOfWheels, passengerCarModel.torgue));
                        break;
                    case PassengerTrain _:
                        var passengerTrainModel = (PassengerTrain)transport;
                        models.Add(new SerializablePassengerTrain(passengerTrainModel.model, passengerTrainModel.maxSpeed, DriverToPDriver(passengerTrainModel.driver), (SerializablePassengerTrain.DistanceType)(passengerTrainModel.distanceType + 1), passengerTrainModel.maxCapacity, passengerTrainModel.amountOfWagons, passengerTrainModel.tractionForce, passengerTrainModel.brakingDistance));
                        break;
                    case FreightTrain _:
                        var freightTrainModel = (FreightTrain)transport;
                        models.Add(new SerializableFreightTrain(freightTrainModel.model, freightTrainModel.maxSpeed, DriverToPDriver(freightTrainModel.driver), freightTrainModel.maxWeight, (SerializableFreightTrain.WagonType)(freightTrainModel.wagonType + 1), freightTrainModel.amountOfWagons, freightTrainModel.tractionForce, freightTrainModel.brakingDistance));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(transport));
                }
            }
            return models;
        }

        public static List<Transport> PTransportsToTransports(List<SerializableTransport> serializableTransport)
        {
            List<Transport> vehicles = new List<Transport>();
            foreach (var transport in serializableTransport)
            {
                switch (transport)
                {
                    case SerializableBus _:
                        var bus = (SerializableBus)transport;
                        vehicles.Add(new Bus(bus.maxCapacity, bus.hasAirConditioning, (Bus.BusType)(bus.type - 1), bus.horsePower, bus.numberOfWheels, bus.torgue, bus.model, bus.maxSpeed, PDriverToDriver(bus.driver)));
                        break;
                    case SerializableTruck _:
                        var truck = (SerializableTruck)transport;
                        vehicles.Add(new Truck(truck.maxWeight, truck.hasTrailer, truck.horsePower, truck.numberOfWheels, truck.torgue, truck.model, truck.maxSpeed, PDriverToDriver(truck.driver)));
                        break;
                    case SerializablePassengerCar _:
                        var passengerCar = (SerializablePassengerCar)transport;
                        vehicles.Add(new PassengerCar((PassengerCar.BodyShape)(passengerCar.bodyShape - 1), passengerCar.numberOfSeats, passengerCar.horsePower, passengerCar.numberOfWheels, passengerCar.torgue, passengerCar.model, passengerCar.maxSpeed, PDriverToDriver(passengerCar.driver)));
                        break;
                    case SerializablePassengerTrain _:
                        var passengerTrain = (SerializablePassengerTrain)transport;
                        vehicles.Add(new PassengerTrain((PassengerTrain.DistanceType)(passengerTrain.distanceType - 1), passengerTrain.maxCapacity, passengerTrain.amountOfWagons, passengerTrain.tractionForce, passengerTrain.brakingDistance, passengerTrain.model, passengerTrain.maxSpeed, PDriverToDriver(passengerTrain.driver)));
                        break;
                    case SerializableFreightTrain _:
                        var freightTrain = (SerializableFreightTrain)transport;
                        vehicles.Add(new FreightTrain(freightTrain.maxWeight, (FreightTrain.WagonType)(freightTrain.wagonType - 1), freightTrain.amountOfWagons, freightTrain.tractionForce, freightTrain.brakingDistance, freightTrain.model, freightTrain.maxSpeed, PDriverToDriver(freightTrain.driver)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(transport));
                }
            }
            return vehicles;
        }
    }
}