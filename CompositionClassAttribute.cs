using System;
namespace DotnetOpenEhr {
    public class CompositionClassAttribute : Attribute {
        string opt;

        public CompositionClassAttribute (string opt) {
            this.opt = opt;
        }
        public string GetOpt () {
            return opt;
        }
    }
}