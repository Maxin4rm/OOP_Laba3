using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;
using System.Xml.Serialization;
using WindowsFormsApp1.SerializableClasses;

namespace WindowsFormsApp1.Serializers
{
	internal class XML_Serializer : SerializerInterface
    {
		public void Serialize(List<Transport> transports, Stream fileStream)
		{
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableTransport>));
            TextWriter writer = new StreamWriter(fileStream);
            serializer.Serialize(writer, ParralelHierarchyConnector.TransportsToPTransports(transports));
        }
		public List<Transport> Deserialize(Stream fileStream)
		{
            XmlSerializer serializer = new XmlSerializer(typeof(List<SerializableTransport>));
            TextReader reader = new StreamReader(fileStream);
            object buff = serializer.Deserialize(reader);
            return ParralelHierarchyConnector.PTransportsToTransports((List<SerializableTransport>)buff);

        }
	}
}
