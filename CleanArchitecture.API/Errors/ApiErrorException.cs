namespace CleanArchitecture.API.Errors
{
    internal class ApiErrorException : ApiErrorResponse
    {
        public string? Details { get; set; }

        public ApiErrorException(int statusCode, string? message, string? details = null) : base(statusCode,message)
        {
            Details=details;
        }
    }
}