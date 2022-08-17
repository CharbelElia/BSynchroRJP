using System;
using System.Linq;

namespace BSynchro.Helpers.Reflection
{
    /// <summary>
    /// The purpose of this class is to provide helper functions to facilitate working with reflection
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Invokes a generic method using reflection
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeObj"></param>
        /// <param name="methodName"></param>
        /// <param name="typeArguments"></param>
        /// <param name="parameters"></param>
        /// <returns>Object representing the method</returns>
        /// <exception cref="ArgumentException"></exception>
        //public static object InvokeGenericMethod(Type type, object typeObj, string methodName, Type[] typeArguments,
        //    params object[] parameters)
        //{
        //    // Since this method is for generic types
        //    if (typeArguments == null || typeArguments.Length == 0)
        //        throw new ArgumentException("Type arguments must be supplied", "typeArguments");
        //    List<MethodInfo> resolveMethods = type.GetMethods().ToList();
        //    if (resolveMethods != null)
        //    {
        //        resolveMethods.AddRange(
        //            type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
        //    }

        //    // Ensure that the method we invoke matches the
        //    // name, type arguments count and number of parameters
        //    var methodsMatchBasicCheck = resolveMethods
        //        .Where(
        //            mi => mi.Name.Equals(methodName) &&
        //                  (mi.GetGenericArguments().Count() == typeArguments.Length &&
        //                   (parameters.Any())
        //                      ? mi.GetParameters().Count() == parameters.Length
        //                      : mi.GetParameters().Count() == 1) /* At least 1 parameter (Extension instance) */)
        //        .ToArray();

        //    // filtering methods in order to select the exact one
        //    MethodInfo resolveMethod = null;
        //    bool found = true;
        //    foreach (MethodInfo methodInfo in methodsMatchBasicCheck)
        //    {
        //        found = true;
        //        var parameterInfoList = methodInfo.GetParameters();
        //        if (!parameters.Any() && parameterInfoList.Any())
        //        {
        //            continue;
        //        }

        //        int i = 0;
        //        foreach (ParameterInfo parameterInfo in parameterInfoList)
        //        {
        //            if (!parameterInfo.ParameterType.IsGenericParameter)
        //            {
        //                if (parameterInfo.ParameterType != typeof(object) &&
        //                    parameterInfo.ParameterType != parameters[i].GetType())
        //                {
        //                    found = false;
        //                    break;
        //                }
        //            }

        //            i++;
        //        }

        //        if (found)
        //        {
        //            resolveMethod = methodInfo;
        //            break;
        //        }
        //    }

        //    if (resolveMethod == null)
        //        return null;

        //    // Invoke method
        //    MethodInfo genericResolveMethod = resolveMethod.MakeGenericMethod(typeArguments);
        //    object res = genericResolveMethod.Invoke(typeObj, parameters);
        //    return res;
        //}

        /// <summary>
        /// Invokes a extension and interface methods using reflection
        /// </summary>
        /// <param name="extensionClass"></param>
        /// <param name="obj"></param>
        /// <param name="predicate"></param>
        /// <param name="typeArguments"></param>
        /// <param name="parameters"></param>
        /// <typeparam name="T"></typeparam>
        //public static void InvokeExtensionAndInterfaceMethods<T>(Type extensionClass, T obj,
        //    Func<MethodInfo, bool> predicate,
        //    Type[] typeArguments, object[] parameters = null)
        //{
        //    var resolveMethods = extensionClass.GetMethods().ToList();
        //    var addScopedMethod = resolveMethods.FirstOrDefault(predicate);
        //    if (addScopedMethod != null)
        //    {
        //        MethodInfo addScopedGenericMethod = null;
        //        addScopedGenericMethod = addScopedMethod.MakeGenericMethod(typeArguments);
        //        addScopedGenericMethod.Invoke(obj, parameters);
        //    }
        //}

        /// <summary>
        /// Invokes a generic static method using reflection
        /// </summary>
        /// <param name="classType"></param>
        /// <param name="methodName"></param>
        /// <param name="typeArguments"></param>
        /// <param name="parametersTypes"></param>
        /// <param name="parameters"></param>
        /// <returns>Object representing the method</returns>
        //public static object InvokeGenericStaticMethod(Type classType, string methodName, Type[] typeArguments,
        //    Type[] parametersTypes,
        //    params object[] parameters)
        //{
        //    List<MethodInfo> resolveMethods = classType.GetMethods()
        //        .Where(m => m.IsStatic && m.IsPublic && m.IsGenericMethod && m.Name.Equals(methodName)).ToList();
        //    var resolveMethod = resolveMethods.FirstOrDefault(i =>
        //        Enumerable.Count<Type>(i.GetGenericArguments()) == typeArguments.Length &&
        //        (parameters.Any())
        //            ? Enumerable.Count<ParameterInfo>(i.GetParameters()) == parameters.Length &&
        //              Enumerable.Select<ParameterInfo, Type>(i.GetParameters(), a => a.ParameterType)
        //                  .SequenceEqual(parametersTypes)
        //            : Enumerable.Count<ParameterInfo>(i.GetParameters()) == 1);

        //    if (resolveMethod == null)
        //    {
        //        return null;
        //    }

        //    MethodInfo genericResolveMethod = resolveMethod.MakeGenericMethod(typeArguments);
        //    object res = genericResolveMethod.Invoke(classType, parameters);
        //    return res;
        //}

        /// <summary>
        /// checks if a type is subclass of another type
        /// </summary>
        /// <param name="generic"></param>
        /// <param name="toCheck"></param>
        /// <returns>boolean</returns>
        //public static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        //{
        //    while (toCheck != null && toCheck != typeof(object))
        //    {
        //        var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
        //        if (generic == cur)
        //        {
        //            return true;
        //        }

        //        toCheck = toCheck.BaseType;
        //    }

        //    return false;
        //}


        /// <summary>
        /// Gets the matching type based 
        /// </summary>
        /// <param name="objType"></param>
        /// <param name="dllNameStr"></param>
        /// <param name="isGeneric"></param>
        /// <param name="isGenericSubClass"></param>
        /// <returns>A list of matching types</returns>
        //public static List<Type> GetMatchingType(Type objType, string dllNameStr, bool isGeneric = true,
        //    bool isGenericSubClass = false)
        //{
        //    var dllName = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "*.dll")
        //        .Where(f => f.Contains(dllNameStr)).FirstOrDefault();

        //    if (!string.IsNullOrEmpty(dllName))
        //    {
        //        Type[] types;
        //        try
        //        {
        //            var assemblyName = AssemblyLoadContext.GetAssemblyName(dllName);
        //            var assembly = new AssemblyLoader(dllName).LoadFromAssemblyName(assemblyName);
        //            types = assembly.GetTypes();
        //            IEnumerable<Type> interestingTypes = null;
        //            if (!isGenericSubClass)
        //            {
        //                interestingTypes =
        //                    types.Where(t => t.GetTypeInfo().IsClass &&
        //                                     !t.GetTypeInfo().IsAbstract &&
        //                                     (t.GetTypeInfo().IsSubclassOf(objType) ||
        //                                      (t.GetTypeInfo().GetInterfaces().Any(i =>
        //                                           i.IsGenericType && i.GetGenericTypeDefinition() == objType) &&
        //                                       isGeneric) ||
        //                                      (objType.IsAssignableFrom(t))
        //                                     ));
        //            }
        //            else
        //            {
        //                List<Type> subClassTypes = new List<Type>();
        //                foreach (var type in types)
        //                {
        //                    if (IsSubclassOfRawGeneric(objType, type))
        //                    {
        //                        subClassTypes.Add(type);
        //                    }
        //                }

        //                interestingTypes = subClassTypes;
        //            }

        //            if (interestingTypes != null)
        //            {
        //                return interestingTypes.ToList();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return null; // Can't load as .NET assembly, so ignore
        //        }
        //    }

        //    return null;
        //}

        /// <summary>
        /// Gets the matching database type based on input
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <returns>Type of the database</returns>
        public static Type GetDatabaseType(string dbType)
        {
            var databaseType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => x.Name == dbType);

            if (databaseType == null)
            {
                throw new Exception("invalid database type");
            }

            return databaseType;
        }
        
        //public static Object GetPropValue(String name, Object obj)
        //{
        //    foreach (String part in name.Split('.'))
        //    {
        //        if (obj == null)
        //        {
        //            return null;
        //        }
        
        //        Type type = obj.GetType();
        //        PropertyInfo info = type.GetProperty(part);
        //        if (info == null)
        //        {
        //            return null;
        //        }
        
        //        obj = info.GetValue(obj, null);
        //    }
        
        //    return obj;
        //}
        
    }
}