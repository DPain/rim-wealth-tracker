using HarmonyLib;
using rim_wealth_tracker.Pages;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using System.Linq;

namespace rim_wealth_tracker {

    /// <summary>
    /// Adds a button to open the Wealth Tracker API UI.
    /// </summary>
    [HarmonyPatch(typeof(OptionListingUtility))]
    [HarmonyPatch("DrawOptionListing")]
    [HarmonyPatch(new Type[] { typeof(Rect), typeof(List<ListableOption>) })]
    class Patch_DrawOptionListing {
        static ListableOption wealthTrackerButton = new ListableOption("UI".Translate(), () => {
            // Removes Menu.
            Find.WindowStack.TryRemove(Find.WindowStack.Windows.Last(), false);
            // Opens a UI to interact with the Wealth Tracker API.
            Find.WindowStack.Add(new Page_UI());
        });
        static void Prefix(Rect rect, List<ListableOption> optList) {

            if (Current.ProgramState == ProgramState.Playing) {
                /**
                 * There two Lists in ProgramState.Playing.
                 * One with type: ListableOption_WebLink and the other with type: ListableOption.
                 */
                if (optList.Count > 0 && optList[0].GetType() == typeof(ListableOption)) {
                    // Only enables Button if tracker is enabled.
                    if (LoadedModManager.GetMod<RimWealthTrackerMod>().GetSettings<Settings>().toggleTracker) {
                        // Add after "Review Scenario".
                        optList.Insert(3, wealthTrackerButton);
                    }
                }
            }
        }
    }
}
