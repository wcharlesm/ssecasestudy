﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SseCaseStudy.Models
{
    public class ITunesSearchResponse<ResultType>
    {
        public List<ResultType> Results { get; set; }
    }
}
