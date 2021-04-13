using System;
using System.Collections.Generic;
using System.Text;

namespace Url_parser.Writer
{
    public interface IWriter<in T>
    {
        public void Write(T[] urlModels, string pathTo);
    }
}
