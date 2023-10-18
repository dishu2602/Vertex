using System;

namespace ConsoleApp
{
    class TemplateArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] integerArray = new int[size];
            double[] doubleArray = new double[size];
            char[] charArray = new char[size];
            string[] stringArray = new string[size];

            Console.WriteLine("\nEnter an element: ");
            string userInput = Console.ReadLine();

            int num;
            bool intResult = int.TryParse(userInput, out num);
            double num1;
            bool doubleResult = double.TryParse(userInput, out num1);
            char num2;
            bool charResult = char.TryParse(userInput, out num2);

            if (intResult)
            {
                Console.WriteLine("\nThe element \'" + userInput + "\' is an Integer.");
                Console.WriteLine("\nNow enter elements in the integer array up to " + size + " size: ");
                integerArray[0] = num;
                Console.WriteLine("1. " + integerArray[0]);
                WritingValues(integerArray, size, "integer");
                Console.WriteLine("\n\t...................PRINTING...................");
                Console.WriteLine("\nINTEGER ARRAY: ");
                PrintArray(integerArray, size);
            }
            else if (doubleResult)
            {
                Console.WriteLine("\nThe element \'" + userInput + "\' is a Double / Float.");
                Console.WriteLine("\nNow enter elements in the double array up to " + size + " size: ");
                doubleArray[0] = num1;
                Console.WriteLine("1. " + doubleArray[0]);
                WritingValues(doubleArray, size, "double");
                Console.WriteLine("\n\t...................PRINTING...................");
                Console.WriteLine("\nDOUBLE ARRAY: ");
                PrintArray(doubleArray, size);
            }
            else if (charResult)
            {
                Console.WriteLine("\nThe element \'" + userInput + "\' is a Character.");
                Console.WriteLine("\nNow enter elements in the character array up to " + size + " size: ");
                charArray[0] = num2;
                Console.WriteLine("1. " + charArray[0]);
                WritingValues(charArray, size, "char");
                Console.WriteLine("\n\t...................PRINTING...................");
                Console.WriteLine("CHARACTER ARRAY: ");
                PrintArray(charArray, size);
            }
            else
            {
                Console.WriteLine("\nThe element \'" + userInput + "\' is a String.");
                Console.WriteLine("\nNow enter elements in the string array up to " + size + " size: ");
                stringArray[0] = userInput;
                Console.WriteLine("1. " + stringArray[0]);
                WritingValues(stringArray, size, "string");
                Console.WriteLine("\n\t...................PRINTING...................");
                Console.WriteLine("STRING ARRAY: ");
                PrintArray(stringArray, size);
            }
        }

        static void PrintArray<T>(T[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine((i + 1) + ". " + array[i]);
            }
            Console.WriteLine();
        }

        static void WritingValues<T>(T[] array, int size, string expectedType)
        {
            for (int i = 1; i < array.Length; i++)
            {
                Console.Write((i + 1) + ". ");
                string userInput = Console.ReadLine();
                if (TryParseValue(userInput, out T result))
                {
                    array[i] = result;
                }
                else
                {
                    Console.Write("You need to enter a " + expectedType + " value. Enter the value for " + (i + 1) + " again: ");
                    i = i - 1;
                }
            }
        }

        static bool TryParseValue<T>(string input, out T result)
        {
            try
            {
                result = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }
    }
}
