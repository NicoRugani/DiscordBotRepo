using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordBot.config{

    internal class JSONReader{

        public string token {get; set; }
        public string prefix{   get; set;}

        public async Task ReadJSON(){
            // Get the current working directory
            string currentDirectory = Directory.GetCurrentDirectory();

            // Specify the relative path to your JSON file
            string filePath = Path.Combine(currentDirectory, "bin/debug/config.json");

            // Use StreamReader to read the contents of the file
            using (StreamReader sr = new StreamReader(filePath)){
                string json = await sr.ReadToEndAsync();
                JsonStructure data = JsonConvert.DeserializeObject<JsonStructure>(json)!;
                this.token = data .token;
                this.prefix = data.prefix;
            }
        }
    }

    internal sealed class JsonStructure{
         public string token {get; set; }
        public string prefix{   get; set;}
    }
    
}
