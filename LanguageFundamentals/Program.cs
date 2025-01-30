using System.Collections;
using EWAD7;

Console.WriteLine("Hello, World!");
string[] friends = { "MG MG", "SU SU", "AYE AYE", "KO KO", "AUNG AUNG", "ZAW ZAW" };
// for(int i=0;i<4;i++){
//     Console.WriteLine(friends[i]);
// }
foreach (string s in friends)
{
    Console.WriteLine(s);
}

Student student = new Student();
student.Name = "MIN MIN";
student.SetAge(20);
Console.WriteLine(student.Name);
Console.WriteLine(student.Age);

foreach (string s in friends)
{
    switch (s)
    {
        case "MG MG": Console.WriteLine("MG MS is closed Friend."); break;
        case "AYE AYE": goto ChildhoodFriend; break;
        default: Console.WriteLine("No friends"); break;
    }
}
ChildhoodFriend:
{
    Console.WriteLine("She is Aye Aye. She is my childhood friend in my native country side");
    goto SayOkay;
}
SayOkay:
{
    Console.WriteLine("Hi,I am MG");
}

IList<string> messages = new List<string>();
messages.Add("Hi");
messages.Add("Hi");
messages.Add("hello");
messages.Add("Nice to see you!!");
foreach (var s in messages)
{//functional programming style in C#.
    Console.WriteLine(s);
}
int[] marks = { 1, 2, 3, 4 };
foreach (var i in marks)
{
    Console.WriteLine(i);
}
Stack myStack=new Stack();//Last in First out (FIFO)
myStack.Push(1);
myStack.Push(2);
Console.WriteLine("output from stack");
Console.WriteLine(myStack.Pop());//2
Console.WriteLine(myStack.Pop());//1
Queue myQueue=new Queue();//First In First Out(FIFO)
myQueue.Enqueue(2);
myQueue.Enqueue(3);
Console.WriteLine("output from queue");
Console.WriteLine(myQueue.Dequeue());//2
Console.WriteLine(myQueue.Dequeue());//3
Dictionary<string,string> mydic=new Dictionary<string, string>();
mydic.Add("exe","execution");
mydic.Add("exe1","execution");
mydic.Add("code","visual studio code");
foreach(var k in mydic){
    Console.WriteLine(k.Key+","+k.Value);
}
