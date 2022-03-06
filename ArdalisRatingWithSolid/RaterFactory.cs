using ArdalisRatingWithSolid.Policies;
using System;

namespace ArdalisRatingWithSolid
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRatingWithSolid.Policies.{policy.Type}PolicyRater"),
                    new object[] { engine, engine.Logger });
            }
            catch
            {
                return null;
            }
        }
    }
}
