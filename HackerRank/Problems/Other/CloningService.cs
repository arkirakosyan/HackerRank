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
    public class CloningService : ICloningService
    {
        public T Clone<T>(T source)
        {
            return Clone(source, new Hashtable());
        }
        private T Clone<T>(T source, Hashtable memo)
        {
            Type type = source.GetType();

            if (type.IsPrimitive || type.IsEnum || type == typeof(string))
            {
                return source;
            }

            if (memo.Contains(source))
            {
                return (T)memo[source];
            }
            memo[source] = null;
            if (type.IsArray)
            {
                Type typeElement = Type.GetType(type.FullName.Substring(0, type.FullName.Length - 2));
                var array = source as Array;
                Array copiedArray = Array.CreateInstance(typeElement, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    var cloneProperty = Clone(array.GetValue(i), memo) ?? copiedArray;
                    copiedArray.SetValue(cloneProperty, i);
                }

                memo[source] = copiedArray;
            }
            else  if (type.IsClass || type.IsValueType)
            {
                if (source is ICollection collection)
                {
                    PropertyInfo[] collectionProperties = type.GetProperties();

                    //var customListType1 = Type.GetType(type.FullName.Split('`')[0] + "<>").MakeGenericType((collectionProperties[collectionProperties.Length - 1]).PropertyType);
                    //var customListType1 = Type.GetType(type.FullName.Split('`')[0] + "<" + type.GenericTypeArguments[0].FullName + "," + type.GenericTypeArguments[1].FullName + ">");
                    var customListType = typeof(List<>).MakeGenericType((collectionProperties[collectionProperties.Length - 1]).PropertyType);
                    var collectionClone = (IList)Activator.CreateInstance(customListType);

                    foreach (var item in collection)
                    {
                        if (item == null)
                            continue;

                        var cloneProperty = Clone(item, memo) ?? collectionClone;
                        collectionClone?.Add(cloneProperty);
                    }

                    memo[source] = collectionClone;
                }
                else
                {
                    object clone = FormatterServices.GetUninitializedObject(type);

                    // Copy fields
                    FieldInfo[] fields = type.GetFields();
                    foreach (FieldInfo field in fields.Where(p => p.IsPublic))
                    {
                        CloningMode cloningMode = CloningMode.Deep;
                        object ct = field.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(Cloneable))?.ConstructorArguments[0].Value;
                        if (ct != null)
                        {
                            cloningMode = (CloningMode)Convert.ToInt32(ct);
                        }

                        if (cloningMode == CloningMode.Ignore) continue;
                        object fieldValue = field.GetValue(source);
                        if (fieldValue != null)
                        {
                            var cloneProperty = Clone(fieldValue, memo) ?? clone;
                            field.SetValue(clone, cloningMode == CloningMode.Deep ? cloneProperty : fieldValue);
                        }
                    }

                    // Copy properties
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo property in properties.Where(p => p.CanRead && p.CanWrite))
                    {
                        CloningMode cloningMode = CloningMode.Deep;
                        object ct = property.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(Cloneable))?.ConstructorArguments[0].Value;
                        if (ct != null)
                        {
                            cloningMode = (CloningMode)Convert.ToInt32(ct);
                        }
                        if (cloningMode == CloningMode.Ignore) continue;

                        object propertyValue = property.GetValue(source);
                        if (propertyValue != null)
                        {
                            var cloneProperty = Clone(propertyValue, memo) ?? clone;
                            property.SetValue(clone, cloningMode == CloningMode.Deep ? cloneProperty : propertyValue);
                        }
                    }
                    memo[source] = clone;
                }

            }
            return (T)memo[source];
        }



        //// Clone the object Properties and its children recursively
        //private object DeepClone<T>(object _desireObjectToBeCloned)
        //{
        //    BindingFlags Binding = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;
        //    Type _primaryType = _desireObjectToBeCloned.GetType();

        //    if (_desireObjectToBeCloned == null)
        //        return null;

        //    if (_primaryType.IsArray)
        //        return ((Array)_desireObjectToBeCloned).Clone();

        //    object tObject = _desireObjectToBeCloned as IList;

        //    if (tObject != null)
        //    {
        //        var properties = _primaryType.GetProperties();
        //        // Get the IList Type of the object
        //        var customList = typeof(List<>).MakeGenericType
        //                         ((properties[properties.Length - 1]).PropertyType);
        //        tObject = (IList)Activator.CreateInstance(customList);
        //        var list = (IList)tObject;
        //        // loop throw each object in the list and clone it
        //        foreach (var item in ((IList)_desireObjectToBeCloned))
        //        {
        //            if (item == null)
        //                continue;
        //            var value = DeepClone<object>(item);
        //            list?.Add(value);
        //        }
        //    }
        //    else
        //    {
        //        // if the item is a string then Clone it and return it directly.
        //        if (_primaryType == typeof(string))
        //            return (_desireObjectToBeCloned as string)?.Clone();

        //        // Create an empty object and ignore its construtore.
        //        tObject = FormatterServices.GetUninitializedObject(_primaryType);
        //        var fields = _desireObjectToBeCloned.GetType().GetFields(Binding);
        //        foreach (var property in fields)
        //        {
        //            if (property.IsInitOnly) // Validate if the property is a writable one.
        //                continue;
        //            var value = property.GetValue(_desireObjectToBeCloned);
        //            if (property.FieldType.IsClass && property.FieldType != typeof(string))
        //                tObject.GetType().GetField(property.Name, Binding)?.SetValue
        //                (tObject, DeepClone<object>(value));
        //            else
        //                tObject.GetType().GetField(property.Name, Binding)?.SetValue(tObject, value);
        //        }
        //    }

        //    return tObject;
        //}


        //private void CopyClass<T>(T copyFrom, T copyTo, bool copyChildren)
        //{
        //    if (copyFrom == null || copyTo == null)
        //        throw new Exception("Must not specify null parameters");

        //    var properties = copyFrom.GetType().GetProperties();

        //    foreach (var p in properties.Where(prop => prop.CanRead && prop.CanWrite))
        //    {
        //        if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
        //        {
        //            if (!copyChildren) continue;

        //            var destinationClass = Activator.CreateInstance(p.PropertyType);
        //            object copyValue = p.GetValue(copyFrom);

        //            CopyClass(copyValue, destinationClass, copyChildren);

        //            p.SetValue(copyTo, destinationClass);
        //        }
        //        else
        //        {
        //            object copyValue = p.GetValue(copyFrom);
        //            p.SetValue(copyTo, copyValue);
        //        }
        //    }
        //}
    }
}
