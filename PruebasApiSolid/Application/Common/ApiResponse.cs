namespace PruebasApiSolid.Application.Common
{
    public class ApiResponse<T>
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public T Data { get; set;}


        public static ApiResponse<T> Ok(T data)
        {
            return new ApiResponse<T>
            {
                State = true,
                Data = data
            };
        }

        public static ApiResponse<string>Fail(string message)
        {
            return new ApiResponse<string>
            {
                State = false,
                Message = message
            };
        }
    }
}
