using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApp1.Serializers;

namespace WindowsFormsApp1.Factories
{
    public class BinaryFactory : SerializerFactory
    {
        public override SerializerInterface CreateSerializer()
        {
            return new Binary_Serializer();
        }
    }
}
