
using Demo.Common.Exceptions;

namespace Demo.Common.Helpers
{
    public static class ValidationHelper
    {
        public static void ValidateNotNull<T>(T entity) where T : class
        {
            if (entity == null)
                throw new ValidationException($"{typeof(T).Name} does not exist!");
        }

        public static void ValidateEntityExists<T>(T entity) where T : class
        {
            if (entity != null)
                throw new ValidationException($"{typeof(T).Name} already exists!");
        }
    }
}
