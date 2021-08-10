using System;
using RimWorld;
using Verse;
using JsonFx.Json;
using System.Collections.Generic;
using rim_wealth_tracker.Pages;

namespace rim_wealth_tracker {
    [StaticConstructorOnStartup]
    public static class Main {
        /**
         * Constructor
         */
        static Main() {
            /**
            var reader = new JsonReader(); var writer = new JsonWriter();

            string input = @"{ ""first"": ""Foo"", ""last"": ""Bar"" }";
            var output = reader.Read<Dictionary<string, object>>(input);
            Log.Message((string)output["first"]); // Foo
            output["middle"] = "Blah";
            string json = writer.Write(output);
            Log.Message(json); // {"first":"Foo","last":"Bar","middle":"Blah"}
            */

        }
    }
}