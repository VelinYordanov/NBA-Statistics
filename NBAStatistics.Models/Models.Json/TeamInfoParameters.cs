﻿using Newtonsoft.Json;

namespace NBAStatistics.Models.Models.Json
{
    public class TeamInfoParameters
    {
        [JsonProperty("teamid")]
        public int TeamID { get; set; }

        [JsonProperty("leagueid")]
        public object LeagueID { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }
    }
}
