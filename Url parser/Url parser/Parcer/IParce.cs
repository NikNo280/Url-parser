using System;
using System.Collections.Generic;
using System.Text;

namespace Url_parser
{
    public interface IParce<out T>
    {
        public T Parce(string source);
    }
}
