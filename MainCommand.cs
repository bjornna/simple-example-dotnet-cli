using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using McMaster.Extensions.CommandLineUtils;
namespace DotnetOpenEhr {
    [Command (Name = "openbifrost-cli",
        FullName = "BIFROST CLI for openEHR",
        Description = "A tool to generate openEHR assets")]
    [VersionOptionFromMember (MemberName = "GetVersion")]
    [HelpOption]
    public class MainCommand {
        [Option ("-i|--input", "Path to the configuration file", CommandOptionType.SingleValue)]
        public string ConfigFile { get; set; }

        [Option ("-v|--verbose", "Display operation details.", CommandOptionType.NoValue)]
        public bool verbose { get; set; }

        [Argument (0, "command", "The command to execute, weight")]
        public string Command { get; set; }

        private string GetVersion () {
            return typeof (MainCommand)
                .Assembly?
                .GetCustomAttribute<AssemblyInformationalVersionAttribute> () ?
                .InformationalVersion;
        }

        private void OnExecute (CommandLineApplication app) {
            Console.WriteLine ("Running application");
            if (string.IsNullOrWhiteSpace (Command)) {
                app.ShowHelp ();
                return;
            }
            if ("weight".Equals (Command)) {
                loadWeights (ConfigFile, verbose);
                return;
            } else {
                app.ShowHelp ();
                return;
            }

        }
        private void loadWeights (string configFile, bool verbose = false) {
            Console.WriteLine ("Loading weights from {0}", configFile);

            var configcontent = File.ReadAllText (configFile);
            WeighHeightConfig config = JsonSerializer.Deserialize<WeighHeightConfig> (configcontent);
            FileServerManager manager = new FileServerManager (config.fileserver);

            foreach (WeightAndHeightData data in config.weights) {

                WeightChartInstance w = new WeightChartInstance (data.when, data.weight, data.height);
                var model = OpenEhrAttributeManager.CreateCompositionModelFromObject (w);

                var template = manager.LoadOpt (model.GetOpt ());
                var compositionBuilder = new DIPS.OpenEhr.Utility.CompositionBuilder ();
                var cid = DIPS.OpenEhr.RM.Support.IdentificationPackage.ObjectVersionId.Create ("bifrost");
                var dict = model.GetDictionary ();
                dict.Add ("/uid", cid);
                dict.Add ("/context/start_time/value", data.when);
                dict.Add ("/context/end_time/value", data.when);
                var composition = compositionBuilder.Create (template, dict);
                var json = DIPS.OpenEhr.RM.Serialization.Json.ReferenceModelJsonSerializer.Serialize (composition, true);
                if (verbose)
                    Console.WriteLine (json);
            }
        }

    }
}