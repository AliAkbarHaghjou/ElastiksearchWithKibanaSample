namespace ElastikSearchWithKibanaSample.Wrapper
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public string? Message { get; set; }

        public Response()
        {
        }

        public Response(T data, string message)
        {
            Data = data;
            Message = message;
            Succeeded = true;
        }

        public Response(string message, bool resultState = false)
        {
            Message = message;
            Succeeded = resultState;
        }
    }
}
