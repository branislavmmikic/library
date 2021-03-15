using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Result
    {
        public static Result Success { get; private set; } = new Result() { IsSuccessful = true };
        private Result() { }

        public Result(string error)
        {
            ErrorMessage = error;
        }

        public bool IsSuccessful { get; private set; }
        
        public string ErrorMessage { get; private set; }
    }
}
