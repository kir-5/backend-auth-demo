using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nks_backend_auth_demo.Models
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}