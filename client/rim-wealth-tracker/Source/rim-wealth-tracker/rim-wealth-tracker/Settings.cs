
using UnityEngine;
using Verse;

namespace rim_wealth_tracker {
    class Settings : ModSettings {
        /// <summary>
        /// The three settings our mod has.
        /// </summary>
        public bool toggleTracker = false;
        public string botAPI = "";

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData() {
            base.ExposeData();

            Scribe_Values.Look<bool>(ref toggleTracker, "toggleTracker", false);
            Scribe_Values.Look<string>(ref botAPI, "botAPI", "");
        }
        public void DoWindowContents(Rect inRect) {
            Listing_Standard list = new Listing_Standard();
            list.Begin(inRect);

            list.Gap(12f);
            list.CheckboxLabeled("ToggleTracker".Translate(), ref toggleTracker);
            list.Label("URL".Translate());
            botAPI = list.TextEntry(botAPI);

            list.End();
        }


        /**
         * Use the following to access Mod settings:
         * LoadedModManager.GetMod<RimWealthTrackerMod>().GetSettings<Settings>().varName;
         * or
         * GetSettings<Settings>().varName;
         */
    }
}
