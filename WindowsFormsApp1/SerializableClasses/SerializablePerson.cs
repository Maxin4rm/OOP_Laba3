using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.SerializableClasses
{

    [Serializable]
    public class SerializablePerson
    {
        public string firstname = "";
        public string lastname = "";
        public enum Sex { InCorrect, Male, Female };
        public Sex sex = Sex.InCorrect;
        public int age = -1;

        public SerializablePerson()
        {

        }

        public SerializablePerson(string _firstname, string _lastname, Sex _sex, int _age)
        {
            this.firstname = _firstname;
            this.lastname = _lastname;
            this.sex = _sex;
            this.age = _age;
        }
    }
}
