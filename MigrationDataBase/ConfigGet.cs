using System.IO;
using System.Text.Json;

namespace MigrationDataBase
{
    public class ConnectionString
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ConnectionString() 
        {
            Name = string.Empty;
        }
    }
    class Config
    {
        public ConnectionString[] ConnectionString { get; set; }

        public Config()
        {
            ConnectionString = new ConnectionString[0];
        }
    }
    public static class ConfigGet
    {
        public static string GetConnectionString(string name)
        {
            string json = File.ReadAllText("config.json");
            Config conf = JsonSerializer.Deserialize<Config>(json);
            return conf.ConnectionString.FirstOrDefault(r => r.Name == name).Value;
        }
    }
}
