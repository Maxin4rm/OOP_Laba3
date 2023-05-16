using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.classes
{
    public class Person
    {
        public string firstname;
        public string lastname;
        
        [Flags]
        public enum Sex { Male, Female };
        public Sex sex;
        public int age;

        public Person(string _firstname, string _lastname, Sex _sex, int _age)
        {
            this.firstname = _firstname;
            this.lastname = _lastname;
            this.sex = _sex;
            this.age = _age;
        }

    }
}
