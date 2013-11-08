using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REP001.Comun.BO
{
    public delegate decimal PayMent(int days);
    public class Employee
    {
        public Person Person { get; set; }
        public long? EmployeeID { get; set; }
        public decimal? PayMent { get; set; }
        public string Position { get; set; }
        //Delegate
        public PayMent CalculatePayMent { get; set; }
        //Event using Action
        public Action OnGeneratePayMent { get; set; }
        //Event using EventHandler
        public event EventHandler<EmployeeEventArg> OnGeneratePayMentEvent = delegate { };

        public decimal GeneratePayment(int days)
        {
            if ( CalculatePayMent == null ) {
                //Sueldo base
                CalculatePayMent = (x) => (decimal.Round(x * 60, 2) - decimal.Round(x * 50, 2) * (decimal).16);
            }
            decimal total = CalculatePayMent(days);
            PayMent = total;
            //RaiseEventOnGeneratePayMent();
            RaiseSafeEventOnGeneratePayMent();
            return total;
        }

        //Raise event
        public void RaiseEventOnGeneratePayMent()
        {
            //Raise  Action
            if ( OnGeneratePayMent != null ) {
                OnGeneratePayMent();
            }

            //Raise even EventHandler
            OnGeneratePayMentEvent(this, new EmployeeEventArg { Employee = this, Error = "Error", Message = "Generate PayMent" });
        }

        //Raise event with exception Handling
        public void RaiseSafeEventOnGeneratePayMent()
        {
            var exceptions = new List<Exception>();
            foreach (Delegate handler in OnGeneratePayMentEvent.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, new EmployeeEventArg { Employee = this, Error = "Error", Message = "Generate PayMent" });
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }


    }
}
