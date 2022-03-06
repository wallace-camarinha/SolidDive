namespace ArdalisRatingWithSolid
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();

            // De-serialize JSON string to a Policy type 
            Policy policy = PolicySerializer.GetPolicyFromJsonString(policyJson);

            var factory = new RaterFactory();

            var rater = factory.Create(policy, this);
            rater?.Rate(policy);

            Logger.Log("Rating completed.");
        }

        // Isolate the logging responsibility to a Logger class
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

        // Isolate the Persistence responsibility to a FilePolicySource class
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();

        // Isolate the Deserializer responsibility to a JsonPolicySerializer class
        public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
    }
}
