﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using REP001.Comun;
using REP001.Comun.BO;
using REP001.Comun.Utilities.math;

namespace REP001.Comun.AplicacionConsola
{
    class Program
    {
        static void Main(string[] args)
        {

            #region **** Test Thread-Events****
            #region *****Thread 01:Simple*********
            //
            //Thread t = new Thread(new ThreadStart(ComunThreading.ThreadMethod));
            //t.Start();
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(string.Format(" Main Thread: {0}", i));
            //    Thread.Sleep(0);
            //}
            //t.Join();
            #endregion

            #region*****Thread 02:Background******

            //Thread t2Background = new Thread(new ThreadStart(ComunThreading.LongThreadMethod));            
            //t2Background.IsBackground = true;
            //t2Background.Start();
            //Thread t2 = new Thread(new ThreadStart(ComunThreading.ThreadMethod));
            //t2.IsBackground = false;
            //t2.Start();
            #endregion

            #region*****Thread 03:Parameter*******
            //Thread t3 = new Thread(new ParameterizedThreadStart(ComunThreading.ParameterThreadMethod));
            //t3.Start(100);
            //Console.ReadLine();
            //t3.Join();

            #endregion

            #region *****Thread 04:Conditional*****
            //Thread t4 = new Thread(new ParameterizedThreadStart(ComunThreading.ConditionalThreadMethod));
            //t4.Start(" \n Lets get start it");
            //Console.WriteLine(" Should i stop it?Y/N");
            //string response = Console.ReadLine();
            //ComunThreading.Stopped = true;
            //t4.Join();
            #endregion

            #region*****Theread 05:Simple task*****
            //Task t1 = Task.Run(() =>
            //{
            //    ComunThreading.SimpleTask();
            //});
            //Task t2 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write("2");
            //        Thread.Sleep(5);
            //    }
            //});
            //t1.Wait();
            //Console.ReadLine();
            #endregion

            #region ********Thread 06:Task<T>*******
            //Task<List<TestData>> taskInf = Task.Run(() =>
            //{
            //    return ComunThreading.GetTestData();

            //}).ContinueWith( (i) => {

            //    foreach (TestData item in i.Result)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //    i.Result.Add(new TestData { ID = 00, Name = "Extra", LastName = "Extra" });
            //    return i.Result;
            //});

            //Console.Write("-------"+ taskInf.Result.Count+"-----");
            //Console.ReadLine();

            //Task<int> t = Task.Run(() =>
            //    {
            //        return 42;
            //    });
            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Cancelar");
            //},TaskContinuationOptions.OnlyOnCanceled);

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Faulted");
            //},TaskContinuationOptions.OnlyOnFaulted);

            //var completedTask = t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Completed");
            //},TaskContinuationOptions.OnlyOnRanToCompletion);
            //completedTask.Wait();
            //Console.ReadLine();
            #endregion

            #region*******Thread 07:Task WaitAll
            //Task[] tasks = new Task[0];
            //tasks[0] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("1");
            //    return 1;
            //});
            //tasks[1] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("2");
            //    return 2;
            //});
            //tasks[2] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("3");
            //    return 3;
            //});
            //Task.WaitAll(tasks); //Espera a que terminen los 3 task


            #endregion

            #region **********Thread 08:Task<T> WaitAny
            //Task<int>[] tasks = new Task<int>[3];

            //tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            //tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            //tasks[2] = Task.Run(()=>{Thread.Sleep(3000);return 3;});

            ////Procesa el Task apenas finaliza
            //while (tasks.Length > 0)
            //{
            //    int i = Task.WaitAny(tasks);
            //    Task<int> completedTask = tasks[i];
            //    Console.WriteLine(completedTask.Result);
            //    var temp = tasks.ToList();
            //    temp.RemoveAt(i);
            //    tasks = temp.ToArray();
            //}
            //Console.ReadLine();
            #endregion

            #region******Thread 09:Async and Wait
            //string result = ComunThreading.DownloadContent().Result;
            //Console.WriteLine(result);
            #endregion

            #region ***** Events and callbacks:simple delegate and events******
            //Employee employee = new Employee {Person = new Person {Name = "Daniela", LastName = "Avila"}};

            ////Event raise on GeneratePayment
            //employee.OnGeneratePayMent += () => Console.WriteLine(string.Format("El pago de {0} {1} fue calculado en un total de {2}", employee.Person.Name, employee.Person.LastName, employee.PayMent));
            ////delegate payment
            //employee.GeneratePayment(15);

            ////remove de others subscribes by using = instead of +=
            //employee.OnGeneratePayMent = () => Console.WriteLine(string.Format("El pago de {0} {1} fue recalcualdo en un total de {2}", employee.Person.Name, employee.Person.LastName, employee.PayMent));

            ////new function for delete payment 
            //employee.CalculatePayMent = (x) => (Decimal.Round(x*90)  - (Decimal.Round((x*89))*(decimal) .16));

            ////Events with EventHandler
            //employee.OnGeneratePayMentEvent += (sender, e) => Console.WriteLine(string.Format("Subscripción 1: al evento GeneratePayMent de {0} {1} pago total={2}", e.Employee.Person.Name, e.Employee.Person.LastName, e.Employee.PayMent));
            //employee.OnGeneratePayMentEvent += (sender, e) => Console.WriteLine(string.Format("Subscripción 2: al evento GeneratePayMent de {0} {1} pago total={2}", e.Employee.Person.Name, e.Employee.Person.LastName, e.Employee.PayMent));

            //employee.GeneratePayment(15);
            #endregion

            #region ***** Events and callbacks:safe events*******

            //Employee employee = new Employee {Person = new Person {Name = "Daniela", LastName = "Avila"}};
            //// Suscribe to Events with EventHandler
            //employee.OnGeneratePayMentEvent += (sender, e) => Console.WriteLine(string.Format("Subscripción 1: al evento GeneratePayMent de {0} {1} pago total={2}", e.Employee.Person.Name, e.Employee.Person.LastName, e.Employee.PayMent));
            //employee.OnGeneratePayMentEvent += (sender, e) => { throw new Exception("Error en un evento"); };
            //employee.OnGeneratePayMentEvent += (sender, e) => { throw new Exception("Error en otro evento"); };
            //employee.OnGeneratePayMentEvent += (sender, e) => Console.WriteLine(string.Format("Subscripción 2: al evento GeneratePayMent de {0} {1} pago total={2}", e.Employee.Person.Name, e.Employee.Person.LastName, e.Employee.PayMent));

            //try
            //{
            //    employee.GeneratePayment(15);
            //}
            //catch (AggregateException ex)
            //{

            //    foreach (Exception s in ex.InnerExceptions)
            //    {
            //        Console.WriteLine(s.Message);
            //    }
            //}


            #endregion
            #endregion


            #region **** Test Utilities****

            //var valores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,21,22,23,24,25 };
            //var funcMcm = new MinimoComunMultiplo();
            //double total =funcMcm.CalcularMinimoComunMultiplo(valores);
            //Console.WriteLine(total);

            var calculo=new CalculoMatematicos();

            //Calculo de espirales de 3x3
            List<long> result = calculo.CalcularSumaDiagonales(4);
            long total = 1;
            foreach (long l in result)
            {
                total = total+ l;
                Console.WriteLine(l);
            }
            #endregion
            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}
