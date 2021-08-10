using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using rim_wealth_tracker.API;
using System.Reflection;

namespace rim_wealth_tracker.Pages {
    class Page_UI : Page {
        private const int NUM_LINES = 5;
        private const float ROW_HEIGHT = 242f;

        private Vector2 pos;
        public volatile List<string> resp;

        public Page_UI() {
            forcePause = true;  // Pauses the game.
            doCloseX = true;
            closeOnCancel = true;

            resp = new List<string>();
        }

        public override string PageTitle => "UI".Translate();
        public override void DoWindowContents(Rect rect) {
            DrawPageTitle(rect);
            Widgets.DrawLine(new Vector2(0f, 30f), new Vector2(rect.width, 30f), Color.gray, 1f);

            Rect rect2 = rect;
            rect2.height = 54f;
            Rect rect3 = rect;
            rect3.yMin = rect2.yMax;
            rect3.height -= 50f;

            Widgets.DrawMenuSection(rect3);

            // White colored text.
            GUI.color = Color.white;

            // Creating a rectangle that will servce as a container.
            Rect baseRect = rect3.ContractedBy(10f);
            float height = (float)API_List.API_Details.Count * ROW_HEIGHT;
            Rect scrollRect = new Rect(0f, 0f, baseRect.width - 27f, height);
            //Rect scrollRect = baseRect.ContractedBy(5f);

            Listing_Standard list = new Listing_Standard();
            Widgets.BeginScrollView(baseRect, ref this.pos, scrollRect, true);
            list.Begin(scrollRect);

            bool isFirst = true;

            for (int i = 0; i < API_List.API_Details.Count; i++) {
                Courier el = API_List.API_Details[i];

                resp.Add("");   // Add an empty value to display to UI.

                if (!isFirst) {
                    list.GapLine(36f);
                } else {
                    isFirst = false;
                }

                GenerateAPIListing(list, el, i);
            }

            list.End();
            Widgets.EndScrollView();

        }

        public async void GenerateAPIListing(Listing_Standard list, Courier el, int i) {
            // Reflection needed for executing function by name.
            Type type = typeof(WealthTrackerAPI);
            MethodInfo method = type.GetMethod(el.funcName);
            WealthTrackerAPI c = LoadedModManager.GetMod<RimWealthTrackerMod>().GetAPI();

            list.Label($"Command: {el.name} \nDescription: {el.description}");
            if (list.ButtonText("Execute")) {
                if (el.returnType == typeof(Task<string>)) {
                    string result;
                    Task<string> func = ((Task<string>)method.Invoke(c, null));
                    result = await func;

                    resp[i] = result;
                } else if (el.returnType == typeof(Task<bool>)) {
                    bool result;
                    Task<bool> func = ((Task<bool>)method.Invoke(c, null));
                    result = await func;

                    resp[i] = result.ToString();
                }
            }

            list.Label("ResponseLabel".Translate());
            list.TextEntry(resp[i], NUM_LINES);   // Read only.
        }
    }
}
