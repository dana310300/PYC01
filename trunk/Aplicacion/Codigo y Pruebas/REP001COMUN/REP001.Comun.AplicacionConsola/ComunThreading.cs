using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace REP001.Comun.AplicacionConsola
{
    public static class ComunThreading
    {
        public static bool Stopped { get; set; }
        public static void ThreadMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(string.Format(" Thread: {0}", i));
                Thread.Sleep(0);
            }

        }
        public static void LongThreadMethod()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(string.Format(" Long Thread: {0}", i));
                Thread.Sleep(250);
            }
        }
        public static void ParameterThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine(string.Format(" Long Thread: {0}", i));
                Thread.Sleep(0);
            }
        }
        public static void ConditionalThreadMethod(object o)
        {

            while (!Stopped)
            {
                Console.WriteLine("Running......" + (string)o);
                Thread.Sleep(1000);
            }
        }
        public static void SimpleTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("1");
                Thread.Sleep(10);
            }
        }
        public static List<TestData> GetTestData()
        {
            List<TestData> ls = new List<TestData>();
            for (int i = 0; i < 100; i++)
            {
                ls.Add(new TestData { ID = i, Name = " Daniela " + i, LastName = " Avila " + i });

                Thread.Sleep(1);
            }
            return ls;
        }

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }

    public class TestData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

    }
}
