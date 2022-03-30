namespace ArdalisRatingWithSolid
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine()
        {
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");
            Context.Log("Loading policy.");

            // load policy - open file policy.json
            var policyJson = Context.LoadPolicyFromFile();

            // De-serialize JSON string to a Policy type 
            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
