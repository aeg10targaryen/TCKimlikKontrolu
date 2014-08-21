namespace TcIdentityChecker.Interfaces
{
    public interface IReturnData<T>
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        T Data { get; set; }
    }

    public class ReturnData<T> : IReturnData<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
