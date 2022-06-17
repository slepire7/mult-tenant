namespace Core.Utils
{
    public class ContentResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
