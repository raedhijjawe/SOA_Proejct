using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChargeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ChargeService.svc or ChargeService.svc.cs at the Solution Explorer and start debugging.
    public class ChargeService : IChargeService
    {
        public CustomerCharge GetCharges(string msisdn)
        {
            using (var context = new SOAEntities())
            {
                var charge = context.CustomerCharges.FirstOrDefault(x => x.msisdn == msisdn);
                return charge;
            }
        }
    }
}
