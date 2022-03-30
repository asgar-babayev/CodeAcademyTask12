using System;
using System.Collections.Generic;
using CollectionsGeneric.Models;
namespace CollectionsGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            //Default List
            List<string> list = new List<string>();
            list.Add("Baku");
            list.Add("Ganja");
            list.Add("Ganja");
            list.Add("Ganja");
            list.Insert(2, "GEn");
            foreach (var item in list)
                Console.WriteLine(item);

            Console.WriteLine(list.Count);

            
            //My Custom List

            MyList<string> myList = new MyList<string>();
            myList.Capacity = 2;
            myList.Add("USA");
            myList.Add("Baku");
            myList.Add("Baku");
            myList.Insert(1, "GEn");
            foreach (var item in myList)
                Console.WriteLine(item);

            Console.WriteLine(myList.Count);
        }
    }

    
}
