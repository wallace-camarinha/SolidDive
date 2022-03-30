namespace ArdalisRatingWithSolid.Policies
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(IRatingUpdater ratingUpdadter) : base(ratingUpdadter) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return;
            }
            _ratingUpdater.UpdateRating(policy.BondAmount * 0.05m);
        }
    }
}
