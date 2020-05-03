using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebApiBestPractices.Entities.Model
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
