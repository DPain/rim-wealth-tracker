using System.Collections.Generic;
using JsonFx.Json;
using UnityEngine;

using RestSharp;
using Verse;
using System;
using System.Reflection;
using HarmonyLib;
using System.Threading.Tasks;
using rim_wealth_tracker.Pages;
using rim_wealth_tracker.API;

namespace rim_wealth_tracker {

    class RimWealthTrackerMod : Mod {

        /// <summary>
        /// A reference to our settings.
        /// </summary>
        private readonly Settings settings;

        private API.WealthTrackerAPI api;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public RimWealthTrackerMod(ModContentPack content) : base(content) {
            Log.Message("[Rim Wealth Tracker] Loading...");

            // Setting up Harmony.
            setUpHarmony();

            this.settings = GetSettings<Settings>();

            bool toggleTracker = this.settings.toggleTracker;
            string botAPI = this.settings.botAPI;

            Log.Message($"[Rim Wealth Tracker] Tracker Toggle: {toggleTracker}");

            if (toggleTracker) {
                try {
                    Task.WaitAll(InitAPI(botAPI));
                } catch (Exception) {
                    this.settings.toggleTracker = false;

                    Log.Message("[Rim Wealth Tracker] Turning off tracker!");
                }


            } else {
                Log.Message("[Rim Wealth Tracker] Skipping API connection due to settings.");
            }

            Log.Message("[Rim Wealth Tracker] Loaded Complete!");
        }

        public async Task InitAPI(string url) {
            Log.Message($"[Rim Wealth Tracker] API URL: {url}");
            try {
                this.api = new WealthTrackerAPI(url);

                bool result = await api.Health();   // Try health check.
                if (!result) {
                    Log.Error("[Rim Wealth Tracker] Couldn't reach the API!");
                }
            } catch (Exception) {
                Log.Error("[Rim Wealth Tracker] API health check fail!");
                this.api = null;
                throw;
            }
        }

        public WealthTrackerAPI GetAPI() {
            return this.api;
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect) {
            settings.DoWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory() {
            return "ModName".Translate();
        }

        public override async void WriteSettings() {
            base.WriteSettings();

            bool activate = this.settings.toggleTracker;
            string url = this.settings.botAPI;
            if (activate && url.Length > 0) {
                try {
                    await InitAPI(url);
                } catch (Exception) {
                    this.settings.toggleTracker = false;

                    Dialog_MessageBox msg = new Dialog_MessageBox("Fail", "OK", () => {
                        Log.Message("[Rim Wealth Tracker] ACTION!");
                    }, null, null, "ModName".Translate(), true, () => {
                        Log.Message("[Rim Wealth Tracker] A!");
                    }, () => {
                        Log.Message("[Rim Wealth Tracker] B!");
                    }, WindowLayer.Dialog);
                    Find.WindowStack.Add(msg);
                    Log.Error("[Rim Wealth Tracker] Turning off tracker due to an error!");
                }
            }
        }

        /// <summary>
        /// Looks for token in the filename: token.json
        /// </summary>
        /// <returns></returns>
        public string loadToken() {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            JsonReader reader = new JsonReader();
            reader.Read("token.json");
            return "";
        }

        /// <summary>
        /// Method to set up Harmony Instance.
        /// </summary>
        public void setUpHarmony() {
            Harmony harmony = new Harmony("dev.dpainhahn.rimwealthtracker");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
