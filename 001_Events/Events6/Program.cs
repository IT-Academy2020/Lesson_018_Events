using System;

// Події.

namespace Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        public event EventDelegate MyEvent = null;

        public void InvokeEvent()
        {
            MyEvent.Invoke();
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
            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);
            instance.MyEvent += delegate { Console.WriteLine("Анонімний метод 1."); };

            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            // Відписка Handler2 ().
            instance.MyEvent -= new EventDelegate(Handler2);

            // Неможливо відписати раніше підписаний анонімний метод.
            instance.MyEvent -= delegate { Console.WriteLine("Анонімний метод 1."); };

            instance.InvokeEvent();

            // Delay.
            Console.ReadKey();
        }
    }
}