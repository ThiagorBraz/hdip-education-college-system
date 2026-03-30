using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSupportAgency_API.Models;

namespace StudentSupportAgency_API.Controllers
{
    public class StudentGrantController : ApiController
    {
        //method to deal with get http request from clients
        //get a parameter if we want the client to send some data to the API
        //returns whatever the clients needs

        [Route ("api/GrantDecision/{ppsNumber}")]
        public DecisionTbl Get(string ppsNumber)
        {
            //create the connection to DB - Grant_DB_ConnectionString

            using (Grant_DB_ConnectionString db = new Grant_DB_ConnectionString())
            {
                //search for the record whic matches the PPS number provided bt the client

                DecisionTbl API_result = new DecisionTbl();
               API_result = db.DecisionTbls.FirstOrDefault(s => s.PPSNumber == ppsNumber);
                if (API_result != null)
                {
                    return API_result;
                }

                else
                {
                    return null;
                }

            }

        }

    }
}
