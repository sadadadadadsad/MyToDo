﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared
{
    public class ApiResponse
    {
        public ApiResponse(string message,bool status=false)
        {
            Message = message;
            Status = status;
        }
        public ApiResponse(bool status,object result)
        {
            Status = status;
            Result = result;
        }

        public string Message { get;  set; }
        public bool Status { get;  set; }
        public object Result { get;  set; }
    }
    public class ApiResponse<T>
    {
        public string Message { get;  set; }
        public bool Status { get;  set; }
        public T Result { get;  set; }
    }
}
