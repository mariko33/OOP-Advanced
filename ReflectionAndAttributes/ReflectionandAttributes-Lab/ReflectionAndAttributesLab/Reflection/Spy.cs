
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fildsNames)
    {
        Type type = Type.GetType(className);

        FieldInfo[] classFilds = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic |
                                                BindingFlags.Public);
        Object classInstance = Activator.CreateInstance(type, new object[] { });
        
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");
        
        foreach (FieldInfo fild in classFilds.Where(f=>fildsNames.Contains(f.Name)))
        {
            
            sb.AppendLine($"{fild.Name} = {fild.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type type=Type.GetType(className);

        FieldInfo[] filds = type.GetFields(BindingFlags.Instance|BindingFlags.Public|BindingFlags.Static);

        MethodInfo[] publicMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        
        StringBuilder sb=new StringBuilder();

        foreach (var fild in filds)
        {
            sb.AppendLine($"{fild.Name} must be private!");
        }

        foreach (var getMethod in nonPublicMethods.Where(g=>g.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getMethod.Name} have to be public!");
        }
        foreach (var setMethod in publicMethod.Where(s=>s.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type=Type.GetType(className);

        MethodInfo[] privateMethyods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        
        StringBuilder sb=new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");
        foreach (var privateMethod in privateMethyods)
        {
            sb.AppendLine(privateMethod.Name);
        }

        return sb.ToString().Trim();

    }


    public string CollectGettersAndSetters(string className)
    {
        Type type=Type.GetType(className);

        MethodInfo[] methodsInfo =
            type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        MethodInfo[] gettersMethods = methodsInfo.Where(g => g.Name.StartsWith("get")).ToArray();
        MethodInfo[] settersMethods = methodsInfo.Where(s => s.Name.StartsWith("set")).ToArray();
        
        StringBuilder sb=new StringBuilder();
        foreach (var getMethod in gettersMethods)
        {
            sb.AppendLine($"{getMethod.Name} will return {getMethod.ReturnType}");
        }

        foreach (var setMethod in settersMethods)
        {
            sb.AppendLine($"{setMethod.Name} will set field of {setMethod.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
