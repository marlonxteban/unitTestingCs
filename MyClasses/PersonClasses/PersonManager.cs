using System;
using System.Collections.Generic;
using System.Text;

namespace MyClasses
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }
                ret.FirstName = first;
                ret.LasTname = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Marlon", LasTname = "Olaya" });
            people.Add(new Person() { FirstName = "Esteban", LasTname = "Ortiz" });
            people.Add(new Person() { FirstName = "Josue", LasTname = "Olaya" });

            return people;
        }

        public List<Person> GetSupervisors()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson("Marlon", "Olaya", true));
            people.Add(CreatePerson("Esteban", "Ortiz", true));

            return people;
        }
    }
}
