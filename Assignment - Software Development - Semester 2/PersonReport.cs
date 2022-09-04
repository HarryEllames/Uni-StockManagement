using System.Collections.Generic;
namespace Assignment___Software_Development___Semester_2
{
    class PersonReport
    {
        int x = 0;
        public static PersonReport PersonLog = new PersonReport();
        public static PersonReport Persons
        {
            get { return PersonLog; }

        }
        public List<Person> Report = new List<Person>();
        private PersonReport() { }

        public void InputPersonData(string PName)
        {
            bool exists = false;
            for (int i = 0; i <= x; i++)
            {
                if (PName == Report[i].PersonName) 
                {
                    exists = true;
                    Report[i].Instances = Report[i].Instances + 1;
                    break;
                }
            }
            if (exists == false)
            {
                //Add new person to list
                Report.Add(new Person());
                Report[x].PersonName = PName;
                Report[x].Instances = 0;
                
                x = x + 1;
            }
        }
    }
}
