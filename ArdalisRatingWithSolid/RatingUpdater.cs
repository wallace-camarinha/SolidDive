﻿using ArdalisRatingWithSolid.Policies;

namespace ArdalisRatingWithSolid
{
    internal class RatingUpdater : IRatingUpdater
    {
        private readonly RatingEngine _engine;

        public RatingUpdater(RatingEngine engine)
        {
            _engine = engine;
        }

        public void UpdateRating(decimal rating)
        {
            _engine.Rating = rating;
        }
    }
}