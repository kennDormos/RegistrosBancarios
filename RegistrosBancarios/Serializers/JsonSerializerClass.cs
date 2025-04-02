using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace RegistrosBancarios.Serializers
{
    public class JsonSerializerClass : ISerializer
    {
        public void Serialize(List<Record> records, string filePath)
        {
            var json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Record> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Record>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Record>>(json) ?? new List<Record>();
        }
    }
}
