﻿using System;
using System.Collections.Generic;

namespace NBAStatistics.Models
{
    public class Season
    {
        private ICollection<PlayersSeasons> players;

        public Season()
        {
            this.players = new HashSet<PlayersSeasons>();
        }

        public int Id { get; set; }

        public ushort StartYear { get; set; }

        public ushort EndYear { get; set; }

        public virtual ICollection<PlayersSeasons> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }
    }
}
