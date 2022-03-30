using ArdalisRatingWithSolid.Policies;

namespace ArdalisRatingWithSolid
{
    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        Policy GetPolicyFromJsonString(string jsonString);
        Policy GetPolicyFromXmlString(string xmlString);
        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
        RatingEngine Engine { get; set; }
    }
}