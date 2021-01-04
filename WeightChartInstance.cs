using DIPS.OpenEhr.RM.DataTypes.DateTimePackage;
using DIPS.OpenEhr.RM.DataTypes.QuantityPackage;
namespace DotnetOpenEhr {
    [CompositionClass ("vekstkurve.opt")]
    public class WeightChartInstance {

        private string origin;

        private double weight;
        private double height;

        public WeightChartInstance (string when, double weight, double height) {
            this.origin = when;
            this.weight = weight;
            this.height = height;
        }
        public WeightChartInstance () {

        }
        public WeightChartInstance withWeight (double w) {
            this.weight = w;
            return this;
        }
        public WeightChartInstance withWhen (string when) {
            this.origin = when;
            return this;
        }

        [AqlPath ("/content[openEHR-EHR-OBSERVATION.body_weight.v2 and name/value='Kroppsvekt']/data[at0002 and name/value='history']/origin")]
        public DvDateTime Origin {
            get {
                DvDateTime dvDateTime = new DvDateTime ();
                dvDateTime.Value = origin;
                return dvDateTime;
            }
        }

        [AqlPath ("/content[openEHR-EHR-OBSERVATION.body_weight.v2 and name/value='Kroppsvekt']/data[at0002 and name/value='history']/events[at0003 and name/value='Uspesifisert hendelse']/data[at0001 and name/value='Simple']/items[at0004 and name/value='Kroppsvekt']/value")]
        public DvQuantity Weight {
            get {
                DvQuantity q = new DvQuantity ();
                q.Magnitude = weight;
                q.Units = "kg";
                return q;
            }
        }

        [AqlPath ("/content[openEHR-EHR-OBSERVATION.body_weight.v2 and name/value='Kroppsvekt']/data[at0002 and name/value='history']/events[at0003 and name/value='Uspesifisert hendelse']/time")]
        public DvDateTime EventTime {
            get {
                return Origin;
            }
        }

        [AqlPath ("/content[openEHR-EHR-OBSERVATION.height.v2 and name/value='Høyde/Lengde']/data[at0001 and name/value='history']/events[at0002 and name/value='Uspesifisert hendelse']/data[at0003 and name/value='Simple']/items[at0004 and name/value='Høyde/lengde']/value")]
        public DvQuantity Height {
            get {
                DvQuantity q = new DvQuantity ();
                q.Magnitude = height;
                q.Units = "cm";
                return q;
            }

        }

    }
}