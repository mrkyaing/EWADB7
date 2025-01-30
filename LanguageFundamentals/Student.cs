
using System.ComponentModel;
namespace EWAD7
{
    public class Student
    {
        public string Name;
        public int Age;

        public void SetAge(int age){//-20
            if(age<0){
                throw new InvalidEnumArgumentException("Inavlid age");
            }
            Age=age;
        }
    }
}