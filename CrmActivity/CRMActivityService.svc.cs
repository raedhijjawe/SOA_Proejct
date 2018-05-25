using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CrmActivity
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CRMActivityService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CRMActivityService.svc or CRMActivityService.svc.cs at the Solution Explorer and start debugging.
    public class CrmActivityService : ICrmActivityService
    {
        public void CreateBusinessInteraction(string msisdn, string note)
        {
            Console.WriteLine("BI Created successfuly");
        }
    }
}
