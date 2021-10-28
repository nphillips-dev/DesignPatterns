using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of Singleton code");
            //Singleton s = new Singleton();  error!
            Console.WriteLine("trying to get first instance");
            Singleton firstInstance = Singleton.GetInstance;
            Console.WriteLine("trying to get second instance");
            Singleton secondInstance = Singleton.GetInstance;

            if (firstInstance.Equals(secondInstance))
            {
                Console.WriteLine("The first and second instances are the same");
            }
            else
            {
                Console.WriteLine("Different instanes exists");
            }

            Console.WriteLine("Start of SingleThreadSingleton");
            Console.WriteLine("trying to get first instance");
            SingleThreadSingleton first = SingleThreadSingleton.Instance;
            Console.WriteLine("trying to get second instance");
            SingleThreadSingleton second = SingleThreadSingleton.Instance;
            if (first.Equals(second))
            {
                Console.WriteLine("The first and second instances are the same");
            }
            else
            {
                Console.WriteLine("Different instanes exists");
            }
            Console.Read();
        }

        /**
         * I have reduced the code to the bare minimum for ease and to remove code smells from sonarlint
         * But to execute custom code, before instansiation e.g. a counter 
         * You would need to use a static constructor
         */
        public sealed class Singleton
        {
            private static readonly Singleton Instance = new Singleton();
            public static Singleton GetInstance => Instance;

            //explicitly stating these is to do with lazy instansiation, see beforeinitfield 
            //might not be needed all the time but need to do more reading.
            static Singleton() { }
            private Singleton() { }
        }

        public class SingleThreadSingleton
        {
            private static SingleThreadSingleton instance;
            private SingleThreadSingleton() { }

            public static SingleThreadSingleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SingleThreadSingleton();
                    }
                    return instance;
                }
            }
        }


    }
}
