using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;
using System.Runtime.Serialization.Formatters.Binary;
using WindowsFormsApp1.SerializableClasses;

namespace WindowsFormsApp1.Serializers
{
    internal class Binary_Serializer : SerializerInterface
    {
        public void Serialize(List<Transport> transports, Stream fileStream)
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, ParralelHierarchyConnector.TransportsToPTransports(transports));
        }
        public List<Transport> Deserialize(Stream fileStream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return ParralelHierarchyConnector.PTransportsToTransports((List<SerializableTransport>)formatter.Deserialize(fileStream));

        }
    }
}
