using System.Runtime.Serialization;

namespace MinimalApiProject.Exceptions
{
    [Serializable]
    internal class NoContentException : Exception
    {
        public NoContentException()
        {
        }

        public NoContentException(string? message) : base(message)
        {
        }
    }
}