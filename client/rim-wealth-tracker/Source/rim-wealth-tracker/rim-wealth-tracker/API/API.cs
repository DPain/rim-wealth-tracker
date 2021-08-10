using RestSharp;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System;

namespace rim_wealth_tracker.API {
    class WealthTrackerAPI {
        private RestClient http;

        public WealthTrackerAPI(string url) {
            http = new RestClient(url);
        }

        public void InvokeMethod(string methodName, List<object> args) {
            GetType().GetMethod(methodName).Invoke(this, args.ToArray());
        }

        public async Task<bool> Health() {
            bool result = false;
            RestRequest req = new RestRequest("health");
            req.Timeout = 10000;

            IRestResponse resp = await http.ExecuteGetAsync(req);
            if (resp.StatusCode == HttpStatusCode.OK) {
                result = true;
            }

            return result;
        }
    }
}
