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
        public string B;

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


            int x = 8;
            int p = cloningService.Clone<int>(x);
            //TestikClass y = cloningService.Clone<TestikClass>(t);
            TestikStruct y = cloningService.Clone<TestikStruct>(t);
            CloningServiceTest c = new CloningServiceTest();
            c.SimpleTest();
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
            Type type = source.GetType();


            if (type.IsPrimitive)
            {
                return source;
            }



            if (type.IsValueType)
            {

                //object instantiatedType =   Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);

                // Create an empty object and ignore its construtore.
                var t = (T)FormatterServices.GetUninitializedObject(type);
                //var t = (T)Activator.CreateInstance(type);
                t = source;
                return t;
            }
            var clone = Activator.CreateInstance(source.GetType());
            return (T)clone;

            var properties = source.GetType().GetProperties();

            foreach (var p in properties.Where(prop => prop.CanRead && prop.CanWrite))
            {
                if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                {
                    var destinationClass = Activator.CreateInstance(p.PropertyType);
                    object copyValue = p.GetValue(source);

                    CopyClass(copyValue, destinationClass, true);

                    p.SetValue(source, destinationClass);
                }
                else
                {
                    object copyValue = p.GetValue(source);
                    p.SetValue(source, copyValue);
                }
            }

            return default(T);
        }



        // Clone the object Properties and its children recursively
        private object DeepClone<T>(object _desireObjectToBeCloned)
        {
            BindingFlags Binding = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy;
            Type _primaryType = _desireObjectToBeCloned.GetType();

            if (_desireObjectToBeCloned == null)
                return null;

            if (_primaryType.IsArray)
                return ((Array)_desireObjectToBeCloned).Clone();

            object tObject = _desireObjectToBeCloned as IList;

            if (tObject != null)
            {
                var properties = _primaryType.GetProperties();
                // Get the IList Type of the object
                var customList = typeof(List<>).MakeGenericType
                                 ((properties[properties.Length - 1]).PropertyType);
                tObject = (IList)Activator.CreateInstance(customList);
                var list = (IList)tObject;
                // loop throw each object in the list and clone it
                foreach (var item in ((IList)_desireObjectToBeCloned))
                {
                    if (item == null)
                        continue;
                    var value = DeepClone<object>(item);
                    list?.Add(value);
                }
            }
            else
            {
                // if the item is a string then Clone it and return it directly.
                if (_primaryType == typeof(string))
                    return (_desireObjectToBeCloned as string)?.Clone();

                // Create an empty object and ignore its construtore.
                tObject = FormatterServices.GetUninitializedObject(_primaryType);
                var fields = _desireObjectToBeCloned.GetType().GetFields(Binding);
                foreach (var property in fields)
                {
                    if (property.IsInitOnly) // Validate if the property is a writable one.
                        continue;
                    var value = property.GetValue(_desireObjectToBeCloned);
                    if (property.FieldType.IsClass && property.FieldType != typeof(string))
                        tObject.GetType().GetField(property.Name, Binding)?.SetValue
                        (tObject, DeepClone<object>(value));
                    else
                        tObject.GetType().GetField(property.Name, Binding)?.SetValue(tObject, value);
                }
            }

            return tObject;
        }


        private void CopyClass<T>(T copyFrom, T copyTo, bool copyChildren)
        {
            if (copyFrom == null || copyTo == null)
                throw new Exception("Must not specify null parameters");

            var properties = copyFrom.GetType().GetProperties();

            foreach (var p in properties.Where(prop => prop.CanRead && prop.CanWrite))
            {
                if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                {
                    if (!copyChildren) continue;

                    var destinationClass = Activator.CreateInstance(p.PropertyType);
                    object copyValue = p.GetValue(copyFrom);

                    CopyClass(copyValue, destinationClass, copyChildren);

                    p.SetValue(copyTo, destinationClass);
                }
                else
                {
                    object copyValue = p.GetValue(copyFrom);
                    p.SetValue(copyTo, copyValue);
                }
            }
        }
    }
}
