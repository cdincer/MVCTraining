using MVCTraining.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCTraining.Extensions
{
    public static class SubscriptionExtensions
    {

        public static async Task<int> GetSubscriptionIdByRegistrationCode(this IDbSet<Subscription> subscription,
                                                                         string code)
        {
            try
            {
                if (subscription == null || code == null || code.Equals(String.Empty))
                {
                    return Int32.MinValue;
                }


            }
            catch
            {

                return Int32.MinValue;
            }
        }
    }
}