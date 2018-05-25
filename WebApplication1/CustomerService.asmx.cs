using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for CustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService
    {
        public decimal Main_Balance;

        [WebMethod]
        public string Charge(decimal amount, string endUserIdentifier, string billingText, string TransactionID, string externalData1, string externalData2, string receivedTime, string serviceIdentifier, string NAI, string currency, string account)
        {
            if (amount < (Main_Balance + 3))
            {
                Main_Balance = Main_Balance - amount;
                return "resp>0</resp>respMessage>Customer charged Successfuly</respMessage>";
                Console.Write("Charge BI at TCRM");
                Console.Write("Charge CDR at EMM");

            }
            else
            {
                return "resp>-1</resp>respMessage>Customer has not enough balance</respMessage>";


            }
        }

        [WebMethod]
        public string Refund(float amount, string endUserIdentifier, string billingText, string TransactionID, string externalData1, string externalData2, string receivedTime, string serviceIdentifier, string NAI, string currency, string account)
        {
            try
            {
                using (var context = new SOAEntities())
                {
                    var customer = context.Customers.FirstOrDefault(x => x.msisdn == endUserIdentifier);
                    var customerBalance = customer.Balance;
                    if ((amount + customerBalance) > 2000)
                    {
                        customer.Balance = customerBalance + amount;
                        context.SaveChanges();
                        return "resp>0</resp>respMessage>Customer refunded Successfuly</respMessage>";
                    }
                    else
                    {
                        return "resp>-1</resp>respMessage>Customer has exceeded the balance limit</respMessage>";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"resp>-1</resp>respMessage>{ex.Message}</respMessage>";
            }

        }

    }
}
