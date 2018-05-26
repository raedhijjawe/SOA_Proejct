using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PromotionsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PromotionsService.svc or PromotionsService.svc.cs at the Solution Explorer and start debugging.
    public class PromotionsService : IPromotionsService
    {

        public float GetRecommendedPromotion(int churnScore)
        {
            return (100 - (float)churnScore * 20) / 100;
        }
    }
}
