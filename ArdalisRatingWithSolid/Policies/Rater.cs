﻿using System;

namespace ArdalisRatingWithSolid.Policies
{
    public class Rater
    {
        protected readonly RatingEngine _engine;
        protected readonly ConsoleLogger _logger;

        public Rater(RatingEngine engine, ConsoleLogger logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public virtual void Rate(Policy policy)
        {
            throw new ArgumentException("Unknown policy type");
        }
    }
}