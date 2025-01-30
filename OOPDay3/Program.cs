// See https://aka.ms/new-console-template for more information
using oopday3;

Console.WriteLine("Hello, World!");
SayHello aPeople=new EnglishPeople();
aPeople.Name="Smith";
aPeople.GreetingMessage();
aPeople.AboutMe();
aPeople.DetailOnMe();
aPeople.WhereAreYouNow();

aPeople=new JapanesePeople();
aPeople.Name="Konasata";
aPeople.GreetingMessage();
aPeople.AboutMe();
aPeople.DetailOnMe();
aPeople.WhereAreYouNow();

aPeople=new MyanmarPeople();
aPeople.Name="MG MG";
aPeople.GreetingMessage();
aPeople.AboutMe();
aPeople.DetailOnMe();
aPeople.WhereAreYouNow();