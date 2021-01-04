using System.IO;
using System.Text.Json;
using DIPS.OpenEhr.AM.Templates;
namespace DotnetOpenEhr {
    public class FileServerManager {
        private string path;
        private FileserverConfig fileserver;

        public FileServerManager (string path) {
            this.path = path;
            this.fileserver = Load ();
        }
        private FileserverConfig Load () {
            var fileserverConfigFile = path + "/fileserver.config";
            var content = File.ReadAllText (fileserverConfigFile);
            return JsonSerializer.Deserialize<FileserverConfig> (content);

        }
        public OperationalTemplate LoadOpt (string optFileName) {
            var optDirPath = path + "/" + fileserver.opts + "/" + optFileName;
            var template = DIPS.OpenEhr.AM.Serialization.OperationalTemplateXmlSerializer.Deserialize (File.ReadAllText (optDirPath));
            return template;

        }
    }
}