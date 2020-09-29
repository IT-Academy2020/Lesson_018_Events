using System;

// Події (abstract and virtual).

namespace Events
{
    public delegate void EventDelegate();

    interface IInterface
    {
        event EventDelegate MyEvent; // Абстрактна подія.
    }

    public class BaseClass : IInterface
    {
        EventDelegate myEvent = null;

        public virtual event EventDelegate MyEvent // Віртуальна подія.
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    public class DerivedClass : BaseClass
    {
        public override event EventDelegate MyEvent // Перевизначення події.
        {
            add
            {
                base.MyEvent += value;
                Console.WriteLine("До події базового класу підписався обробник - {0}", value.Method.Name);
            }
            remove
            {
                base.MyEvent -= value;
                Console.WriteLine("Від події базового класу відписався обробник - {0}", value.Method.Name);
            }
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