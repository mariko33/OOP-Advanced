using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            ConstructorInfo ctor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            
            BlackBoxInteger classInstance =(BlackBoxInteger)ctor.Invoke(null);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Static);

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic); 

            string input;
            while ((input=Console.ReadLine())!="END")
            {
                var args = input.Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
                string methodName = args[0];
                int param = int.Parse(args[1]);

                MethodInfo targetMethod = methods.FirstOrDefault(m=>m.Name==methodName);
                FieldInfo targetField = type.GetField("innerValue");

                int index = 0;
                
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i] == targetField) index = i;
                }
                targetMethod.Invoke(classInstance, new object[]{param});
                Console.WriteLine(fields[index].GetValue(classInstance));
                
            }
        }
    }
}
