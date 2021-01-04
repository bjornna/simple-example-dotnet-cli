using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetOpenEhr {
    [DebuggerDisplay ("{" + nameof (GetDebuggerDisplay) + "(),nq}")]
    public class CompositionModel {
        string opt;
        Dictionary<string, object> dictionary;

        public CompositionModel (string opt, Dictionary<string, object> dict) {
            this.opt = opt;
            this.dictionary = dict;
        }
        public string GetOpt () {
            return opt;
        }
        public Dictionary<string, object> GetDictionary () {
            return dictionary;
        }

        private string GetDebuggerDisplay () {
            return ToString ();
        }
        public override string ToString () {
            StringBuilder sb = new StringBuilder ();
            foreach (KeyValuePair<string, object> kvp in GetDictionary ()) {
                sb.AppendFormat ("{0}: {1}\n", kvp.Value, kvp.Key);
            }
            sb.AppendFormat ("OPT = {0} ", opt);
            return sb.ToString ();
        }

    }
}