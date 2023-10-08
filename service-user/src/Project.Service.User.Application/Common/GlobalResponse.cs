using Newtonsoft.Json;

namespace Project.Service.User.Application.Common
{
    public class GlobalResponse<T>
    {
        public GlobalResponse()
        {
        }

        [JsonIgnore]
        public bool Status 
        {
            get
            {
                return (ErrorMessage is null);
            }
        }

        [JsonProperty(("Data"), NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }

        [JsonProperty(("ErrorMessage"), NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ErrorMessage { get; set; }
    }
}
