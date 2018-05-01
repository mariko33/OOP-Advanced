using System.Linq;
using System.Text;

namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        Console.WriteLine(GetPrivateFields(type));
                        break;
                    case "protected":
                        Console.WriteLine(GetProtectedFields(type));
                        break;
                    case "public":
                        Console.WriteLine(GetPublicFields(type));
                        break;
                    case "all":
                        Console.WriteLine(GetAllFields(type));
                        break;
                }

            }
        }

        private static string GetAllFields(Type type)
        {
            FieldInfo[] allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();

            foreach (var fild in allFields)
            {
                string modifier = fild.Attributes.ToString().ToLower();
                if(fild.IsFamily) modifier = "protected";
                 
                sb.AppendLine($"{modifier} {fild.FieldType.Name} {fild.Name}");
            }

            return sb.ToString().Trim();
        }

        private static string GetPublicFields(Type type)
        {
            FieldInfo[] publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            foreach (var fild in publicFields.Where(f=>f.IsPublic))
            {
                sb.AppendLine($"{fild.Attributes.ToString().ToLower()} {fild.FieldType.Name} {fild.Name}");
            }

            return sb.ToString().Trim();
        }

        private static string GetProtectedFields(Type type)
        {
            FieldInfo[] protectedFilds = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();
            foreach (var fild in protectedFilds.Where(p => p.IsFamily))
            {

                sb.AppendLine($"protected {fild.FieldType.Name} {fild.Name}");
            }

            return sb.ToString().Trim();
        }

        private static string GetPrivateFields(Type type)
        {
            FieldInfo[] privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var fild in privateFields.Where(f=>f.IsPrivate))
            {
                sb.AppendLine($"{fild.Attributes.ToString().ToLower()} {fild.FieldType.Name} {fild.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
