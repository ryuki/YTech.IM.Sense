﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using YTech.IM.Sense.Core.Transaction;
using YTech.IM.Sense.Enums;
using YTech.IM.Sense.Data.Repository;
using YTech.IM.Sense.Core.RepositoryInterfaces;
using YTech.IM.Sense.Core;

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

        public static TReference GetReference(EnumReferenceType referenceType)
        {
            ITReferenceRepository referenceRepository = new TReferenceRepository();
            TReference reference = referenceRepository.GetByReferenceType(referenceType);
            if (reference == null)
            {
                reference = new TReference();
                reference.SetAssignedIdTo(Guid.NewGuid().ToString());
                reference.ReferenceType = referenceType.ToString();
                reference.ReferenceValue = "0";
                reference.CreatedDate = DateTime.Now;
                reference.DataStatus = EnumDataStatus.New.ToString();
                referenceRepository.Save(reference);
                referenceRepository.DbContext.CommitChanges();
            }
            return reference;
        }

        public static string GetFacturNo(EnumTransactionStatus transactionStatus)
        {
            TReference refer = GetReference((EnumReferenceType)Enum.Parse(typeof(EnumReferenceType), transactionStatus.ToString()));
            ITReferenceRepository referenceRepository = new TReferenceRepository();
            decimal no = Convert.ToDecimal(refer.ReferenceValue) + 1;
            refer.ReferenceValue = no.ToString();
            referenceRepository.Update(refer);
            referenceRepository.DbContext.CommitChanges();

            string tipeTrans = string.Empty;
            char[] charTransArray = transactionStatus.ToString().ToCharArray();
            char charTrans;

            for (int i = 0; i < transactionStatus.ToString().Length; i++)
            {
                charTrans = charTransArray[i];
                if (char.IsUpper(transactionStatus.ToString(), i))
                    tipeTrans += transactionStatus.ToString().Substring(i, 1);
            }
            string formatFactur = "SENSE/[TRANS]/[XXX]/[MONTH]/[YEAR]";
            StringBuilder result = new StringBuilder();
            result.Append(formatFactur);
            result.Replace("[TRANS]", tipeTrans);
            result.Replace("[XXX]", GetFactur(5, no));
            result.Replace("[MONTH]", DateTime.Today.ToString("MMM").ToUpper());
            result.Replace("[YEAR]", DateTime.Now.Year.ToString());
            return result.ToString();
        }

        public static string GetVoucherNo()
        {
            TReference refer = GetReference(EnumReferenceType.VoucherNo);
            ITReferenceRepository referenceRepository = new TReferenceRepository();
            decimal no = Convert.ToDecimal(refer.ReferenceValue) + 1;
            refer.ReferenceValue = no.ToString();
            referenceRepository.Update(refer);
            referenceRepository.DbContext.CommitChanges();

            string formatFactur = "SENSE/[XXX]/[MONTH]/[YEAR]";
            StringBuilder result = new StringBuilder();
            result.Append(formatFactur);
            result.Replace("[XXX]", GetFactur(5, no));
            result.Replace("[MONTH]", DateTime.Today.ToString("MMM").ToUpper());
            result.Replace("[YEAR]", DateTime.Now.Year.ToString());
            return result.ToString();
        }

        private static string GetFactur(int maxLength, decimal no)
        {
            int len = maxLength - no.ToString().Length;
            string factur = no.ToString();
            for (int i = 0; i < len; i++)
            {
                factur = "0" + factur;
            }
            return factur;
        }

        //public static IEnumerable<T> WriteHtmlLi<T>(IEnumerable<T> composites)
        //{
        //    foreach (var composite in composites)
        //    {
        //        yield return composite;
        //    }
        //}

        //public class Functional
        //{

        //    private delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);

        //    public static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        //    {

        //        Recursive<A, R> rec = r => a => f(r(r))(a);

        //        return rec(rec);

        //    }

        //}



    }
}
