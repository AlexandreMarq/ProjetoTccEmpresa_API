namespace Infra.CrossCutting.ExteralAndHelpers
{
    public static class GenericTypeExtensions
    {
        public static string ToStringList<T>(this IEnumerable<T> source, char separator = ',')
        {
            return string.Join(separator, source);
        }
    }
}
