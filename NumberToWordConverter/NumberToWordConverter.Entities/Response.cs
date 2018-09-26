namespace NumericToWord.Entities
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
