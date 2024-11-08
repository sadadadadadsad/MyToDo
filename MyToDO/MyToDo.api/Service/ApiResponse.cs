namespace MyToDo.api.Service
{
    /// <summary>
    /// 通用的返回结果
    /// </summary>
    public class ApiResponse
    {
        public ApiResponse(string message /*错误消息*/,bool status=false) //失败
        {
            Message = message;
            Status = status;
        }
        public ApiResponse(bool status,object result ) // 返回结果
        {
            Status = status;
            Result = result;
            
        }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Result { get; set; }
    }
}
