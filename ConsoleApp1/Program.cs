// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;
using Calc.Controllers; // Подключаем Dll
using Microsoft.AspNetCore.Routing;
using System.IO;

namespace Reflection
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("Client1.cs");
                sw.WriteLine("namespace ClientCalculator");
                sw.WriteLine("{");
                sw.WriteLine("using System = global::System;");

            // класс Calculate
            Type type = Type.GetType("Calc.Controllers.Calculate, Calc", true, false);
            var members = type.GetMembers();
            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine(memberInfo.Name);
            }

            // класс Calculator
            type = Type.GetType("Calc.Calculator, Calc", true, false);

            members = type.GetMembers();

            try
            {
                sw.WriteLine($"public class {type.Name}");
                sw.WriteLine("{");
                foreach (MemberInfo memberInfo in members)
                {
                    if (memberInfo.MemberType is MemberTypes.Property)
                    {
                        sw.WriteLine($"public double {memberInfo.Name}");
                        sw.WriteLine(" { get; set; }");
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            sw.WriteLine("}");
            sw.Close();
        }
    }

}

