using System;

// Події.

namespace Events
{
    public delegate void EventDelegate();

    public class MyClass
    {
        EventDelegate myEvent = null;

        // Реалізація методів доступу add і remove для події.
        public event EventDelegate MyEvent
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

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
            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);

            // Метод який викликає подія.
            instance.InvokeEvent();

            Console.WriteLine(new string('-', 20));

            // Відписка Handler2 ().
            instance.MyEvent -= new EventDelegate(Handler2);
            instance.InvokeEvent();

            // Delay.
            Console.ReadKey();
        }
    }
}