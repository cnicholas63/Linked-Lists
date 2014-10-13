using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTest
{

    class Test<T>
    {
        private T obj;
        private String name = "Chris Nicholas";

        public Test(T obj)
        {
            this.obj = obj;
        }

        public String getName()
        {
            return name;
        }

        public T getObject()
        {
            return obj;
        }
    }

    class MyObject 
    {
        public Random t = new Random();
        private int value;

        public MyObject()
        {
            value = t.Next(0, 101);
        }

        public int getValue()
        {
            return value;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyObject hello = new MyObject();
            MyObject temp;

            Test<MyObject> testObject = new Test<MyObject>(hello); // Create new Test object (testObject) of type MyObject passing object (hello)
                       
            temp = testObject.getObject(); // Cast the object held in testObjectg to type MyObject

            Console.WriteLine(temp.getValue() + " " + testObject.getName());

            Console.ReadKey();

        }
    }
}
