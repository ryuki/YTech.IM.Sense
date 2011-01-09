using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YTech.IM.Sense.Web.Controllers.Helper
{
    public class CommonHelper
    {
        public static string DateFormat
        {
            get { return "dd-MMM-yyyy"; }
        }
        public static string DateTimeFormat
        {
            get { return "dd-MMM-yyyy HH24:mm"; }
        }
        public static string NumberFormat
        {
            get { return "N2"; }
        }

        public static IEnumerable<T> WriteHtmlLi<T>(IEnumerable<T> composites)
        {
            foreach (var composite in composites)
            {
                yield return composite;
            }
        }

        public class Functional
        {

            private delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);

            public static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
            {

                Recursive<A, R> rec = r => a => f(r(r))(a);

                return rec(rec);

            }

        }

     

    }
}
