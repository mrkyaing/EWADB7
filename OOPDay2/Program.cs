// See https://aka.ms/new-console-template for more information
using oopday2;

Console.WriteLine("Hello, World!");
Cat myCat=new ();
myCat.Name="Jacky";
myCat.AgeInMonth=3;
myCat.Speak();
myCat.Eat();//eat fired-fish

Dog myDog=new Dog(){
Name="royal",
AgeInMonth=8
};
myDog.Speak();
myDog.Bark();
myDog.Eat();//eating smoething

BullDog aBullDog=new();
aBullDog.Eat();

try
{
    Student s1 = new Student();
    s1.SetAge(30);
    s1.SetEmail("susu@gmail.com");
    s1.PostalCode = 101;
    s1.Address = "YGN";
    s1.ZipCode = 16;
    var result = s1.CheckZipCode();
    if (!result) Console.WriteLine("Invalid Zip Code");
    s1.NRC = "12/DAT";
    Console.WriteLine(s1.GetAge());
    Console.WriteLine(s1.GetEmail());//null
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}