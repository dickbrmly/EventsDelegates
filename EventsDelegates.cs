using System;

namespace EventsAndDelegates 
{
    class EventObject
    {
        delegate void Mydel(string s);// A delegate that can hold functions 
                                      // to called in its invocation list.
        delegate void Anonymous();    // Anonymous method invocation.

        static void Main(string[] args)
        {
            Mydel del = TestFunction; // TestFunction added to invocation list.
            del += TestFunction; // Add another instanciation of TestFunction
                                 // to the invocation list. If return type--then last
                                 // function's return value is used.
            del("Hello there.");
            TestFunction("It's all good!"); //direct use of the function.

            Anonymous MyAnon = delegate  //Anonymous function attached to delegate.
            {
                for(int x=0;x<5;x++)
                {
                    System.Console.WriteLine("{0} count",x);
                }
            };

            MyAnon(); //call to anonymous delegate.
        }
        static void TestFunction(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}