﻿namespace Hospital.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statuscode, string? message = null)
        {
            StatusCode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);
        }


        private string? GetDefaultMessageForStatusCode(int statuscode)
        {
            return statuscode switch
            {
                400 => "A Bad Request , You Have Made",
                401 => "Authorized , You Are Not",
                404 => "Recource was Not Found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
