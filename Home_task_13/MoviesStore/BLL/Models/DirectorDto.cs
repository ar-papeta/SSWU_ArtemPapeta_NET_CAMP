﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class DirectorDto
    {
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}
