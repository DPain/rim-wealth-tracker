using RestSharp;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System;
using RimWorld;
using Verse;

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
            RestRequest req = new RestRequest("health") {
                Timeout = 5000
            };

            IRestResponse resp = await http.ExecuteGetAsync(req);
            if (resp.StatusCode == HttpStatusCode.OK) {
                result = true;
            }

            return result;
        }

        public async Task<bool> SubmitWealth() {
            bool result = false;

            if (Current.ProgramState == ProgramState.Playing) {
                RestRequest req = new RestRequest("wealth") {
                    Timeout = 5000
                };

                var body = new {
                    wealth = WealthUtility.PlayerWealth,
                    days = (float)Find.TickManager.TicksGame / (float)GenDate.TicksPerDay,
                    name = SteamUtility.SteamPersonaName.Length > 0 ? SteamUtility.SteamPersonaName : "Player"
                };

                req.AddJsonBody(body);

                IRestResponse resp = await http.ExecutePostAsync(req);
                if (resp.StatusCode == HttpStatusCode.OK) {
                    result = true;
                }
            }

            return result;
        }
    }
}
