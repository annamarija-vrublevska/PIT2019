using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIT_2019.Models
{
    [Serializable]
    public class JsonActionResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}