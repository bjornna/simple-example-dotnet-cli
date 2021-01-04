namespace DotnetOpenEhr {
    public class AqlPathAttribute : System.Attribute {
        /// The AQL path for the attribute
        string path;
        public AqlPathAttribute (string path) {
            this.path = path;
        }
        public string GetPath () {
            return path;
        }
    }
}