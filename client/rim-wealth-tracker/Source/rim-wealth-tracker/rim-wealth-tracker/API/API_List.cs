using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rim_wealth_tracker.API {
    class API_List {
        public static List<Courier> API_Details = new List<Courier> {
            new Courier("Health Check", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Submit Wealth", "Submits the world's wealth to the API.", "SubmitWealth", typeof(Task<bool>)),
            new Courier("Health Check3", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check4", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check5", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check6", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check7", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check8", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check9", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check10", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check11", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check12", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check13", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>)),
            new Courier("Health Check14", "Pings the Wealth Tracker API.", "Health", typeof(Task<bool>))
        };
    }
}
