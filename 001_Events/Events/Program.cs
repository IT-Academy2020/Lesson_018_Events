using System;

// Події.

namespace Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        public event EventDelegate myEvent = null;

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    class Program
    {
        // Методи обробники події.

        static private void Handler1()
        {
            Console.WriteLine("Обробник події 1");
        }

        static private void Handler2()
        {
            Console.WriteLine("Обробник події 2");
        }

        static void Main()
        {
            MyClass instance = new MyClass();

            // Підписка на подію.
            instance.myEvent += new EventDelegate(Handler1);
            instance.myEvent += Handler2;

            // Метод який викликає подію.
            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            // Відписка Handler2 ().
            instance.myEvent -= new EventDelegate(Handler2);

            instance.InvokeEvent();

            // Delay.
            Console.ReadKey();
        }
    }
}