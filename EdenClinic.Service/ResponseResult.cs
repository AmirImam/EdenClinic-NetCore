/*
*
* Generated At 9/7/2020 9:10:36 AM
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Service
{
    public class ResponseResult<T>
    {
        public T Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

    }

    public class Innererror
    {
        public string message { get; set; }
        public string type { get; set; }
        public string stacktrace { get; set; }
    }

    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
        public Innererror innererror { get; set; }
    }

    public class RequestError
    {
        public Error error { get; set; }
    }

    public class ExceptionObject 
    {
        public Exception Exception { get; set; }
        public string ODataCommand { get; set; }
    }
}
