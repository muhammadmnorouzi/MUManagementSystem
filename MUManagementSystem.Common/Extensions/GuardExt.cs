namespace MUManagementSystem.Common.Extensions
{
    public static class GuardExt
    {
        public static string ThrowIfNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str)
                ? throw new ArgumentNullException(nameof(str))
                : str;
        }

        public static T ThrowIfNull<T>(this T data) where T : class
        {
            return data is null
                ? throw new ArgumentNullException(nameof(data))
                : data;
        }

        public static decimal ThrowIfNegative(this decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("value can not be negative.");
            }

            return value;
        }
    }
}
