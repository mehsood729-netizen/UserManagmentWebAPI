namespace UserManagmentWebAPI.API_Response
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }


        public static APIResponse<T> SuccessResponse(T data)
        {
            return new APIResponse<T>
            {
                Data = data,
                IsSuccess = true,

            };
        }

        public static APIResponse<T> ErrorResponse(string error)
        {
            return new APIResponse<T>
            {
                Error = error,
                IsSuccess = false

            };
        }
    }
}
