
    using System;
    using System.Linq;
    using System.Reflection;
    using InfernoInfinity2.Enums;

public static class GemFactory
    {
        public static Gem GetGem(string type,LevelOfClarity clarity)
        {
            Assembly currentAssembly=Assembly.GetExecutingAssembly();

            var currentType = currentAssembly.GetTypes().FirstOrDefault(g => g.Name == type);

            return (Gem) Activator.CreateInstance(currentType, clarity);
        }
    }
