namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        { }
        public SuccessDataResult(T data) : base(data, true)
        { }
        public SuccessDataResult(Abstract.IDataResult<System.Collections.Generic.List<global::Entities.Concrete.CarImage>> dataResult, string message) : base(default, true, message)
        { }
        public SuccessDataResult() : base(default, true)
        { }
    }
}
