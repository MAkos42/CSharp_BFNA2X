using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharp_feladat
{
    class ConcDict
    {
        public ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();




        public void AddValues(int count)
        {
            CountdownEvent cde = new CountdownEvent(count);
            Thread thr1 = new Thread(() => AddMethod(cde));
            Thread thr2 = new Thread(() => AddMethod(cde));
            Thread thr3 = new Thread(() => AddMethod(cde));
            Thread thr4 = new Thread(() => AddMethod(cde));
            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();
            thr1.Join();
            thr2.Join();
            thr3.Join();
            thr4.Join();
            cde.Dispose();
        }

        public void AddMethod(CountdownEvent cde)
        {
            int i = 0;
            while (!cde.IsSet)
            {
                try
                {
                    cde.Signal();
                    dict.TryAdd(Guid.NewGuid().ToString(), i);
                    i++;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
        }

        public int Count => dict.Count;

        public void PrintDict()
        {
            foreach (var entry in dict)
            {
                Console.WriteLine("{0}\t{1}", entry.Key, entry.Value);
            }
        }

        public void DoubleValues()
        {
            foreach(var entry in dict)
            {
                dict.AddOrUpdate(entry.Key, 100, (key, oldvalue) => oldvalue * 2);
            }
        }

        public void RemoveAt(string key)
        {
                int value;
            Console.WriteLine(dict.TryRemove(key, out value) ? "Torolt elem erteke: " + value.ToString() : "Nem letezo kulcs/index");
        }

        public void RemoveAt(int index)
        {
            try
            {
                string key = dict.Keys.ToList()[index];
                int value;
                Console.WriteLine(dict.TryRemove(key, out value) ? "Torolt elem erteke: " + value.ToString() : "Nem letezo kulcs/index");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Nem letezo kulcs/index");
            }
        }
    }
}
