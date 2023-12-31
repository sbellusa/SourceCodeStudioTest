﻿using SourceCodeStudioTest.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SourceCodeStudioTest.Models
{
    public class DogResponse : ResponseBase
    {
        [JsonPropertyName("message")]
        public string Url { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
