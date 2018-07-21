﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Domain.Contracts
{
    public class Issue : IIssue
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Estimate { get; set; }
        public string Status { get; set; }
        public List<string> PastStates { get; set; }
    }
}
