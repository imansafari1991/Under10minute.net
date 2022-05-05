using System;
using System.Runtime.InteropServices;

namespace ConsoleExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Immutable 
            string name1 = "Iman";
            string name2 = name1;
            GCHandle gchName1 = GCHandle.Alloc(name1, GCHandleType.Pinned);
            IntPtr pObjName1 = gchName1.AddrOfPinnedObject();
            Console.WriteLine($"Address of name1 before change in memory is '{pObjName1}'");

            GCHandle gchName2 = GCHandle.Alloc(name2, GCHandleType.Pinned);
            IntPtr pObjName2 = gchName1.AddrOfPinnedObject();
            Console.WriteLine($"Address of name2 before change name1 in memory is '{pObjName2}'");
            name1 = "Amir";
            GCHandle gchName1AfterChange = GCHandle.Alloc(name1, GCHandleType.Pinned);
            IntPtr pObjName1AfterChange = gchName1AfterChange.AddrOfPinnedObject();
            Console.WriteLine($"Address of name1 after change in memory is '{pObjName1AfterChange}'");

            GCHandle gchName2AfterChangeName1 = GCHandle.Alloc(name2, GCHandleType.Pinned);
            IntPtr pObjName2AfterChangeName1 = gchName2AfterChangeName1.AddrOfPinnedObject();
            Console.WriteLine($"Address of name2 before change name1 in memory is '{pObjName2AfterChangeName1}'");
            Console.WriteLine($"name1 is:{name1}");
            Console.WriteLine($"name2 is:{name2}");


            // Mutable
            Person person1 = new Person() { Name = "iman" };
            Person person2 = person1;
            person1.Name = "amir";
            Console.WriteLine(person1.Name);
            Console.WriteLine(person2.Name);

            //Immutable class

            ImmutablePerson immutablePerson1 = new ImmutablePerson("iman");
            ImmutablePerson immutablePerson2 = immutablePerson1;



        }
    }
}
