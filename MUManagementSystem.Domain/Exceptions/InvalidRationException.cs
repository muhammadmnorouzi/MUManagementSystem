namespace MUManagementSystem.Domain.Exceptions
{
    public class InvalidRationException : Exception
    {
        public InvalidRationException() : base("Ration can not be zero or negative.")
        {

        }
    }
}
