using System.Collections;
namespace DotnetOpenEhr {

    public class WeighHeightConfig {
        public string fileserver { get; set; }
        public WeightAndHeightData[] weights { get; set; }
    }
    public class WeightAndHeightData {
        public string when { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
    }

    /// <summary>DTO to map path variables for Fileserver repositories</summary>
    public class FileserverConfig {
        public string name { get; set; }
        public string forms { get; set; }
        public string opts { get; set; }

        public string archetypes { get; set; }

        public string vaqms { get; set; }
        public string form_scripts { get; set; }
        public string form_tests { get; set; }
        public string data { get; set; }
        public string concepts { get; set; }

        public string foldertemplates { get; set; }

    }
}