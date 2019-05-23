using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public struct TestikStruct
    {
        public int A;
        public string B;
        public TestikClass Test;
        public TestikStruct(int a, string b, TestikClass t)
        {
            A = a;
            B = b;
            Test = t;
        }
    }

    public class TestikClass
    {
        public int A;
        [Cloneable(CloningMode.Deep)]
        public string B;
        [Cloneable(CloningMode.Ignore)]
        public bool T { get; set; }
        public TestikClass(int a, string b)
        {
            A = a;
            B = b;
        }
    }
    public class CloneTester : _ProblemBase
    {
        public override void MainRun()
        {
            CloningService cloningService = new CloningService();
            //TestikClass t = new TestikClass(5, "asd");
            TestikStruct t = new TestikStruct(5, "asd", new TestikClass(1, "A"));


            TestikClass tt = new TestikClass(1, "1");
            TestikClass tt1 = new TestikClass(1, "1");
            int[] xx = new int[] { 1, 2, 3, 4, 5 };
            string aaa = "aaa";
            //int x = 8;
            //int p = cloningService.Clone<int>(x);
            //TestikClass y = cloningService.Clone<TestikClass>(tt);
            //var bbb = cloningService.Clone<int[]>(xx);



            CloningServiceTest c = new CloningServiceTest();
            //c.CollectionTest();
            c.RunAllTests();
        }
    }

    public interface ICloningService
    {
        T Clone<T>(T source);
    }
    public enum CloningMode
    {
        Ignore,
        Deep,
        Shallow,
    }
    public class Cloneable : Attribute
    {
        public CloningMode CloneMode;

        public Cloneable(CloningMode cloneMode)
        {
            this.CloneMode = cloneMode;
        }
    }
    public class CloningService : ICloningService
    {
        private Dictionary<object, object> memo = new Dictionary<object, object>();
        //public T Clone<T>(T source)
        //{

        //    return Clone(source, new Dictionary<object, object>());
        //}
        public T Clone<T>(T source)
        {
            Type type = source.GetType();

            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return source;
            }

            if (memo.ContainsKey(source))
            {
                return (T)memo[source];
            }

            if (type.IsArray)
            {
                Type typeElement = Type.GetType(type.FullName.Substring(0, type.FullName.Length - 2));
                var array = source as Array;
                Array copiedArray = Array.CreateInstance(typeElement, array.Length);
                memo[source] = copiedArray;
                for (int i = 0; i < array.Length; i++)
                {
                    copiedArray.SetValue(Clone(array.GetValue(i)), i);
                }
            }
            else  if (type.IsClass || type.IsValueType)
            {
                if (source is ICollection && type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>)))
                {
                    var collectionClone = Activator.CreateInstance(type.GetGenericTypeDefinition().MakeGenericType(type.GetGenericArguments()));
                    memo[source] = collectionClone;

                    var method = collectionClone.GetType().GetMethod("Add");

                    foreach (var item in source as ICollection)
                    {
                        method.Invoke(collectionClone, new[] { Clone(item) });
                    }
                }
                else
                {
                    object clone = Activator.CreateInstance(type);
                    memo[source] = clone;

                    // Copy fields
                    FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    foreach (FieldInfo field in fields)
                    {
                        CloningMode cloningMode = field.IsDefined(typeof(Cloneable)) ? (field.GetCustomAttribute<Cloneable>()).CloneMode : CloningMode.Deep;
                        if (cloningMode == CloningMode.Ignore) continue;

                        object fieldValue = field.GetValue(source);
                        if (fieldValue != null)
                        {
                            field.SetValue(clone, cloningMode == CloningMode.Deep ? Clone(fieldValue) : fieldValue);
                        }
                    }

                    // Copy properties
                    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead && p.CanWrite);
                    foreach (PropertyInfo property in properties)
                    {
                        CloningMode cloningMode = property.IsDefined(typeof(Cloneable)) ? (property.GetCustomAttribute<Cloneable>()).CloneMode : CloningMode.Deep;
                        if (cloningMode == CloningMode.Ignore) continue;

                        object propertyValue = property.GetValue(source);
                        if (propertyValue != null)
                        {
                            property.SetValue(clone, cloningMode == CloningMode.Deep ? Clone(propertyValue) : propertyValue);
                        }
                    }
                }
            }
            return (T)memo[source];
        }
    }
}
