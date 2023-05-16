using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApp1.classes;

namespace WindowsFormsApp1.SerializableClasses
{

    [Serializable]
    [XmlInclude(typeof(SerializablePassengerCar))]
    [XmlInclude(typeof(SerializableTruck))]
    [XmlInclude(typeof(SerializableBus))]
    [XmlInclude(typeof(SerializableFreightTrain))]
    [XmlInclude(typeof(SerializablePassengerTrain))]
    public abstract class SerializableTransport
    {
        public string model = "";
        public int maxSpeed = -1;
        public SerializablePerson driver;


        public SerializableTransport() { }
        public SerializableTransport(string _model, int _maxSpeed, SerializablePerson _driver)
        {
            this.model = _model;
            this.maxSpeed = _maxSpeed;
            this.driver = _driver;
        }

        public static void CheckFields(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType == typeof(string))
                {
                    if ((string)field.GetValue(obj) == "")
                        throw new Exception($"Field '{field.Name}' isn't fulfilled");
                    string value = (string)field.GetValue(obj);
                    if (value.Length > 16)
                        throw new Exception($"Field '{field.Name}' has value \"{value}\" that was longer than 16 symbols");
                    string pattern = "^[A-Za-z\\s]*$";
                    if (!Regex.IsMatch(value, pattern))
                        throw new Exception($"Field '{field.Name}' has value \"{value}\" with invalid symbols (only english letters and whitespaces are allowed)");
                }
                else if (field.FieldType == typeof(int))
                {
                    if ((int)field.GetValue(obj) == -1)
                        throw new Exception($"Field '{field.Name}' isn't fulfilled");
                    int value = (int)field.GetValue(obj);
                    if (value < 0 || value > Int32.MaxValue)
                        throw new Exception($"Field '{field.Name}' value is {value} < 0");
                }                
                else if (field.FieldType == typeof(bool))
                {
                    try
                    {
                        bool value = (bool)field.GetValue(obj);
                    }
                    catch {
                        throw new Exception($"Field '{field.Name}' contains incorrect value");
                    }
                }
                else if (field.FieldType.IsEnum)
                {
                    if ((int)field.GetValue(obj) == 0)
                        throw new Exception($"Field '{field.Name}' isn't fulfilled");
                }
                else
                {
                    if (field.GetValue(obj) == null)
                        throw new Exception($"Field '{field.Name}' isn't fulfilled");
                    CheckFields(field.GetValue(obj));
                }
            }
        }

    }
}
