using CHClinic.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHClinic.Models.Views
{
    
    public class PeopleList
    {
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<History> Histories { get; set; }
    }
}