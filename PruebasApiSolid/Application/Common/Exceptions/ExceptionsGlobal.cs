namespace PruebasApiSolid.Application.Common.Exceptions
{

    public sealed class NotFoundException : ApplicationExceptionBase
    {
        public NotFoundException() : base("Usurio no encontrado") { }
    }

    public sealed class ValidationExceptions : ApplicationExceptionBase
    {
        public ValidationExceptions(string message) : base(message) { }
    }

    public sealed class ConflictExceptions : ApplicationExceptionBase
    {
        public ConflictExceptions(string message) : base(message) { }
    }
}
