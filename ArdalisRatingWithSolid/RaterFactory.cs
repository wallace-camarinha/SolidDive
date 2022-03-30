using ArdalisRatingWithSolid.Policies;
using System;

namespace ArdalisRatingWithSolid
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, IRatingContext context)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRatingWithSolid.Policies.{policy.Type}PolicyRater"),
                    new object[] { new RatingUpdater(context.Engine) });
            }
            catch
            {
                return new UnknownPolicyRater(new RatingUpdater(context.Engine));
            }
        }
    }
}
