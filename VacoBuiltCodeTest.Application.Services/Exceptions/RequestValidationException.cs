namespace VacoBuiltCodeTest.Application.Services.Exceptions
{
    public sealed class RequestValidationException
    {

        public IEnumerable<string> Errors { get; }

        public RequestValidationException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
