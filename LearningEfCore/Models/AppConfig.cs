namespace LearningEfCore.Models
{
    internal class AppConfig
    {
        public string ConnectionString { get; set; }

        public AppConfig() { }
        internal AppConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
