using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace LearningEfCore.Tools
{
    internal class JsonHandler<Model> where Model : class, new ()
    {
        internal JsonHandler() { }

        internal void Serialize(Model model, string jsonPath)
        {
            var jsonString = JsonConvert.SerializeObject(model);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);

            try
            {
                using FileStream file = File.Create(jsonPath);
                file.Write(jsonBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Model Deserialize(string jsonPath)
        {
            string jsonString;
            Stream file = File.OpenRead(jsonPath);
            using StreamReader reader = new StreamReader(file);
            jsonString = reader.ReadToEnd();

            try
            {
                return JsonConvert.DeserializeObject<Model>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
