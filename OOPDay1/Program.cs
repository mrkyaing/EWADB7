// See https://aka.ms/new-console-template for more information
using OOPDay1;
using TeacherInfo;

Console.WriteLine("Hello, World!");
Car myCar=new Car();
Console.WriteLine(myCar.LicenceNo);
Console.WriteLine(myCar.GearNo);
myCar.Drive();
myCar.PlayHorn();

Car yourCar=new Car("YGN","D");
Console.WriteLine(yourCar.LicenceNo);//YGN
Console.WriteLine(yourCar.GearNo);//D
yourCar.Drive();
yourCar.PlayHorn(5);

Car aCar=new Car("MDY");
Console.WriteLine(aCar.LicenceNo);//MDY
Console.WriteLine(aCar.GearNo);//No Gear
aCar.Drive();
aCar.PlayHorn(10);
aCar.PlayHorn();

Car.Stop();
Console.WriteLine(Car.DisplayTime);

Console.WriteLine(Utility.Key);//10
Utility.SayHello();//Hi

StudentInfo.Student.StudentDetail();//fully qulified name calling for namespace .
Teacher.TeacherDetail();