using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace RegistrosBancarios.Serializers
{
    public class XmlSerializerClass : ISerializer
    {
        public void Serialize(List<Record> records, string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<Record>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, records);
            }
        }

        public List<Record> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Record>();
            var serializer = new XmlSerializer(typeof(List<Record>));
            using (var reader = new StreamReader(filePath))
            {
                return (List<Record>)serializer.Deserialize(reader) ?? new List<Record>();
            }
        }
    }
}