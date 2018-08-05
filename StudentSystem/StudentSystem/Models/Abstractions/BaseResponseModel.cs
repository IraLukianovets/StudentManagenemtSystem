namespace StudentSystem.API.Models.Abstractions
{
    public abstract class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}