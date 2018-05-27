using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates 
{
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    class EventObject
    {
        delegate void Mydel(string s);// A delegate that can hold functions 
                                      // to called in its invocation list.
    //***************************************************************************************
        delegate void Anonymous();    // Anonymous method invocation.
    //***************************************************************************************
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

            var p = new EventAlarm(); //Publisher
            var s = new MakeSound(); //Subscriber (could have more).

            p.sound += s.soundoff;  // 
            p.sounder();

         
            MyAnon += () => System.Console.WriteLine("Lambda baby!"); //new invocation using 
                                                                      // lambda expression

            MyAnon(); //call to anonymous delegate.
        }
    //***************************************************************************************
        static void TestFunction(string text)
        {
            System.Console.WriteLine(text);
        }
    //***************************************************************************************
    }
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    public class MakeSound
    {
        public void soundoff(object source, EventArgs e)
        {
            System.Console.Beep();
        }
    }
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    public class EventAlarm
    {
        /* 1 - Define a delegate
           2 - Define an event based on that delegate.
           3 - Raise the event. */
        //public delegate void MyEventHandler(object source, EventArgs args);
        public event EventHandler sound; // no need to define a delegate.
        public void sounder()
        {
            onSoundRequest(); //call the virtual function
        }
   //***************************************************************************************
        protected virtual void onSoundRequest()
        {
            if(sound != null) //at least one function exists in sound.
            {
                sound(this,EventArgs.Empty); //just emit the sound.
            }
        }
    }
    //***************************************************************************************
    //***************************************************************************************
    //***************************************************************************************
    //*************************************************************************************** 
}