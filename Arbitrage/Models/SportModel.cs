﻿namespace Arbitrage.Models
{
    public class SportModel
    {
        public string Key { get; set; }
        public string Group { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool HasOutrights { get; set; }
    }
}
