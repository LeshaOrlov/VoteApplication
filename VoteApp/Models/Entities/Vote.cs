﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Models.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OptionId { get; set; }
    }
}
