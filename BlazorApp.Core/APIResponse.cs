namespace BlazorApp.Core
{
    public class APIResponse
    {
        public string Version { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
