using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.Helpers
{
    public static class LinqExtensions
    {

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOder<T>(source, property, "OrderBy");
        }

        static IOrderedQueryable<T> ApplyOder<T>(IQueryable<T> source, string property, string methodName)
        {

            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expres = arg;

            foreach ( string prop in props ) {
                //Use reflection to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expres = Expression.Property(expres, pi);
                type = pi.PropertyType;

                
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expres, arg);

            object result = typeof(Queryable).GetMethods().Single(
        method => method.Name == methodName
                && method.IsGenericMethodDefinition
                && method.GetGenericArguments().Length == 2
                && method.GetParameters().Length == 2)
        .MakeGenericMethod(typeof(T), type)
        .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }


      
    }
}
