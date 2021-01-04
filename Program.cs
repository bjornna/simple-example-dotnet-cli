using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DIPS.OpenEhr.AM.Serialization;
using DIPS.OpenEhr.RM.Domain.Compositions.CompositionPackage;
using DIPS.OpenEhr.Utility;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;
namespace DotnetOpenEhr {
    class Program {

        public static void Main (string[] args) {
            CommandLineApplication.Execute<MainCommand> (args);
        }

    }
}