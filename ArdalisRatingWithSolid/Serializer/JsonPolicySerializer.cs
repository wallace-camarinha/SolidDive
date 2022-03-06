using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ArdalisRatingWithSolid
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string jsonString)
        {
            try
            {

                return JsonConvert.DeserializeObject<Policy>(jsonString,
                    new StringEnumConverter());
            }
            catch
            {
                return null;
            }
        }

    }
}
