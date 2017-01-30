using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class GenericListValue
    {
        public string Value { get; set; }
        public string Content { get; set; }

        public string Default
        {
            get
            {
                return _Default;
                ;
            }
            set { _Default = value; }
        }

        private string _Default = "false";
    }
}
