using System;

namespace TravelBlogs.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        //Свойство Succeed указывает, успешна ли операция
        public bool Succeed { get; protected set; }
        public string Property { get; protected set; }
        public ValidationException(string message, string prop, bool succ)
            : base(message)
        {
            Property = prop;
            Succeed = succ;
        }
    }
}
