using System;
using System.Collections.Generic;
using System.Reflection;
namespace DotnetOpenEhr {
    public class OpenEhrAttributeManager {
        public static CompositionModel CreateCompositionModelFromObject (Object obj, bool verbose = false) {

            var dict = new Dictionary<string, object> ();
            Type t = obj.GetType ();
            var compositionClass = Attribute.GetCustomAttribute (t, typeof (CompositionClassAttribute)) as CompositionClassAttribute;
            if (compositionClass != null) {
                var opt = compositionClass.GetOpt ();
                PropertyInfo[] props = t.GetProperties (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var prop in props) {
                    if (verbose)
                        Console.Write ("{0}", prop.Name);
                    AqlPathAttribute pathAttribute = Attribute.GetCustomAttribute (prop, typeof (AqlPathAttribute)) as AqlPathAttribute;
                    if (prop.GetIndexParameters ().Length == 0) {
                        if (pathAttribute != null) {
                            if (verbose)
                                Console.WriteLine (" {0}: {1}", prop.GetValue (obj), pathAttribute.GetPath ());
                            dict.Add (pathAttribute.GetPath (), prop.GetValue (obj));

                        }
                    }
                }
                return new CompositionModel (opt, dict);
            } else {
                return null;
            }

        }

    }
}