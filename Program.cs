using System;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public delegate void SumofNumbersCallback(int SumOfNumber);


    class Number
    {
        int _target;
        SumofNumbersCallback _callbackMethod;
        public Number(int target, SumofNumbersCallback calllbackMethod)
        {
            this._target = target;
            this._callbackMethod = calllbackMethod;

        }
        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 1; i <= _target; i++)
            {
                sum += 1;
            }
            if (_callbackMethod != null)
            {
                _callbackMethod(sum);
            }
        }

    }

    public class Video55
    {
        public static string GetFullName(string fn, string ln)
        {
            Console.WriteLine("First Name:{0} && Second Name:{1}", fn, ln);
            return (fn + ln);
        }
    }

    public class Video56
    {
        public static bool AreEqual<T>(T a1, T a2)
        {
            return a1.Equals(a2);
        }
    }

    class Program
    {

        public static void Video67(int firstNumber, int SecondNumber, params object[] restofNumbers)
        {
            int result = firstNumber + SecondNumber;
            if (restofNumbers != null)
            {
                foreach (int i1 in restofNumbers)
                {
                    result += i1;
                }
            }
            Console.WriteLine("Sum=" + result);
        }

        public static void Video68(int firstNumber, int SecondNumber)
        {

            Video68(firstNumber, SecondNumber, null);
        }

        public static void Video68(int firstNumber, int SecondNumber, int[] restofNumbers)
        {
            int result = firstNumber + SecondNumber;
            if (restofNumbers != null)
            {
                foreach (int i1 in restofNumbers)
                {
                    result += i1;
                }
            }
            Console.WriteLine("Sum=" + result);
        }

        //we can make parameters can be made optional by specifying last parameter with default value
        public static void Video69(int firstNumber, int SecondNumber, int[] restofNumbers = null)
        {
            int result = firstNumber + SecondNumber;
            if (restofNumbers != null)
            {
                foreach (int i1 in restofNumbers)
                {
                    result += i1;
                }
            }
            Console.WriteLine("Sum=" + result);
        }

        public static void Video70(int firstNumber, int SecondNumber, [Optional] int[] restofNumbers)
        {
            int result = firstNumber + SecondNumber;
            if (restofNumbers != null)
            {
                foreach (int i1 in restofNumbers)
                {
                    result += i1;
                }
            }
            Console.WriteLine("Sum=" + result);
        }

        public static void Video91(int sum)
        {
            Console.WriteLine("Sum of numbers callback" + sum);
        }

        public static void Video91Invoker()
        {
            Console.WriteLine("Please Enter the target Number");
            int target = Convert.ToInt32(Console.ReadLine());

            SumofNumbersCallback callback = new SumofNumbersCallback(Video91);

            Number number = new Number(target, callback);
            Thread T1 = new Thread(new ThreadStart(number.PrintSumOfNumbers));
            T1.Start();

        }
        static void Main(string[] args)
        {
            //main mein likha karo code
            Assembly exeassembly = Assembly.GetExecutingAssembly();
            Type customerType = exeassembly.GetType("ConsoleApp1.Video55");
            object customerInstance = Activator.CreateInstance(customerType);
            MethodInfo getFullNameMethod = customerType.GetMethod("GetFullName");
            string[] parameters = new string[2];
            parameters[0] = "ret";
            parameters[1] = "1";
            object fullname = getFullNameMethod.Invoke(customerInstance, parameters);
            fullname = (string)fullname;
            Console.WriteLine("Full Name={0}", fullname);
            //late binding is slower than early binding, in early binding we will get error at compile time
            /////////////////////////////////////56////////////////////////////////////////////////////////
            Console.WriteLine();
            bool Equal = Video56.AreEqual<int>(1, 2);
            Console.WriteLine("Are the parameters equal? {0}", Equal);


            //Video91Invoker();
            //Video67(10,20,30,40,50);
            //Video67(10,20,new object[] {10,20,30 });
            //params array has to be the last array
            //Video68(10,20,new int[] { 10,20,30});
            //Video69(10,20,restofNumbers:new int[] { 20, 30., 40 });
            //we can specify what optional variable we want to provide
            //Video70(10, 20, new int[] { 10, 20, 30 });
        }
    }
}
