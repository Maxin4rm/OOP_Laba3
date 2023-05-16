using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.classes;
using WindowsFormsApp1.SerializableClasses;

namespace WindowsFormsApp1.Serializers
{
    internal class Txt_Serializer : SerializerInterface
    {
        public void Serialize(List<Transport> transports, Stream fileStream)
        {
            List<SerializableTransport> PlItems = ParralelHierarchyConnector.TransportsToPTransports(transports);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine("<");
            foreach (var PlItem in PlItems)
            {
                Type modelType = PlItem.GetType();
                writer.WriteLine($"{modelType.Name.Replace("SerializableModel", "")}{{");
                foreach (var field in modelType.GetFields())
                {
                    var value = field.GetValue(PlItem);
                    if (field.FieldType.IsPrimitive || field.FieldType == typeof(string) || field.FieldType.IsEnum)
                    {
                        writer.WriteLine($"\t{field.Name} : {value}");
                    }
                    else
                    {
                        Type insertedObjectType = field.FieldType;
                        writer.WriteLine($"\t{field.Name} :\n\t{insertedObjectType.Name.Replace("Model", "")}{{");

                        foreach (var nestedField in insertedObjectType.GetFields())
                        {
                            var nestedValue = nestedField.GetValue(value);
                            writer.WriteLine($"\t\t{nestedField.Name} : {nestedValue}");
                        }

                        writer.WriteLine("\t}");
                    }
                }
                writer.WriteLine("}");
            }
            writer.Write(">");
            writer.Flush();
        }

        public List<Transport> Deserialize(Stream fileStream)
        {
            List<SerializableTransport> PlItems = new List<SerializableTransport>();
            StreamReader reader = new StreamReader(fileStream);
            string currLine = ReadNextLine(reader);
            if (!currLine.Trim().Equals("<")) throw new Exception("Error (line " + currLine.Trim() + " )");
            while (!reader.EndOfStream)
            {
                currLine = ReadNextLine(reader);
                if (currLine.Trim().EndsWith("{"))
                {
                    AssembleTransport(out object PlItem, reader, currLine);
                    SerializableTransport.CheckFields(PlItem);
                    PlItems.Add((SerializableTransport)PlItem);
                }
                else
                    if (currLine.Trim().StartsWith(">"))
                    break;
                else
                    throw new Exception("Error (line " + currLine.Trim() + " )");
            }
            return ParralelHierarchyConnector.PTransportsToTransports(PlItems);

        }

        private string ReadNextLine(StreamReader reader)
        {
            if (reader.EndOfStream) 
                throw new Exception("End of file found, but object info expected");
            string currLine;
            do {
                 currLine = reader.ReadLine();
            } while (currLine.Trim() == "");
            return currLine;
        }


        private void AssembleTransport(out object PlItem, StreamReader reader, string currLine)
        {
            Type modelType = Type.GetType("WindowsFormsApp1.SerializableClasses." + currLine.Trim().Substring(0, currLine.Trim().Length - 1)) ?? throw new Exception("Error (line " + currLine.Trim() + " )");
            PlItem = Activator.CreateInstance(modelType);
            while (!reader.EndOfStream && !currLine.Trim().StartsWith("}"))
            {
                currLine = ReadNextLine(reader);
                if (currLine.Trim().StartsWith("}")) break;
                string[] parts = currLine.Trim().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                string propertyName = parts[0].Trim();
                FieldInfo field = modelType.GetField(propertyName) ?? throw new Exception("Error (line " + currLine.Trim() + " )");
                if (parts.Length >= 2)
                {
                    if (parts.Length >= 3)
                        throw new Exception("Error (line " + currLine.Trim() + " )");
                    string propertyValue = parts[1].Trim();
                    if (field.FieldType.IsPrimitive || field.FieldType == typeof(string) || field.FieldType.IsEnum)
                    {
                        if (field.FieldType.IsEnum)
                        {
                            object enumValue;
                            try
                            {
                                enumValue = Enum.Parse(field.FieldType, propertyValue);
                            }
                            catch {
                                throw new Exception("Error (line " + currLine.Trim() + " )");
                            };
                            field.SetValue(PlItem, enumValue);
                        }
                        else
                        {
                            TypeCode typeCode = Type.GetTypeCode(field.FieldType);
                            object convertedValue;
                            try
                            {
                                convertedValue = Convert.ChangeType(propertyValue, typeCode);
                            }
                            catch { 
                                throw new Exception("Error (line " + currLine.Trim() + " )");
                            };
                            field.SetValue(PlItem, convertedValue);
                        }
                    }
                }
                else
                {
                    if (parts.Length > 1) 
                        throw new Exception("Error (line " + currLine.Trim() + " )");
                    object insertedObj;
                    Type insertedObjectType = field.FieldType;
                    insertedObj = Activator.CreateInstance(insertedObjectType);
                    currLine = ReadNextLine(reader);
                    if (!currLine.Trim().EndsWith("{") || (currLine.Trim().Split(new[] { ' ' }).Length > 1))
                        throw new Exception("Error (line " + currLine.Trim() + " )");
                    currLine = ReadNextLine(reader);
                    while (!reader.EndOfStream && !currLine.Trim().StartsWith("}"))
                    {
                        string[] insertedParts = currLine.Trim().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                        string insertedPropertyName = insertedParts[0].Trim();
                        FieldInfo insertedFieldInfo = insertedObjectType.GetField(insertedPropertyName) ?? throw new Exception("Error (line " + currLine.Trim() + " )");
                        if (insertedParts.Length != 2) 
                            throw new Exception("Error (line " + currLine.Trim() + " )");
                        string insertedPropertyValue = insertedParts[1].Trim();
                        if (insertedFieldInfo.FieldType.IsEnum)
                        {
                            object enumValue;
                            try
                            {
                                enumValue = Enum.Parse(insertedFieldInfo.FieldType, insertedPropertyValue);
                            }
                            catch { 
                                throw new Exception("Error (line " + currLine.Trim() + " )");
                            };
                            insertedFieldInfo.SetValue(insertedObj, enumValue);
                        }
                        else
                        {
                            TypeCode insertedFieldTypeCode = Type.GetTypeCode(insertedFieldInfo.FieldType);
                            object insertedConvertedValue;
                            try
                            {
                                insertedConvertedValue = Convert.ChangeType(insertedPropertyValue, insertedFieldTypeCode);
                            }
                            catch { 
                                throw new Exception("Error (line " + currLine.Trim() + " )");
                            };
                            insertedFieldInfo.SetValue(insertedObj, insertedConvertedValue);
                        }
                        currLine = ReadNextLine(reader);
                    }
                    field.SetValue(PlItem, insertedObj);
                    currLine = "";
                }
            }
        }
    }
}
