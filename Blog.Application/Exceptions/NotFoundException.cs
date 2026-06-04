using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Blog.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name,object key) : base($"Entity {name} ({key}) was not found")
        {
        }
    }
}
