using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;

namespace WindowsFormsApp1
{

    public interface SerializerInterface
    {
        void Serialize(List<Transport> transports, Stream fileStream);
        List<Transport> Deserialize(Stream fileStream);
    }
}
