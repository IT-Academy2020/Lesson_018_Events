using System;

// Події (abstract and virtual).

namespace Events
{
    public delegate void EventDelegate();

    interface IInterface
    {
        event EventDelegate MyEvent;
        void InvokeEvent();
    }

    public class BaseClass : IInterface
    {
        public virtual event EventDelegate MyEvent = null;

        public virtual void InvokeEvent()
        {
            MyEvent.Invoke();
        }
    }

    public class DerivedClass : BaseClass
    {
        public override event EventDelegate MyEvent = null;

        public override void InvokeEvent()
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
            DerivedClass instance = new DerivedClass();

            // Підписка на подію.
            instance.MyEvent += new EventDelegate(Handler1);
            instance.MyEvent += new EventDelegate(Handler2);

            // Метод який викликає подію.
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