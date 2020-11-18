using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.DTOs
{
    public class ShowTableDto
    {
        public ShowTableDto()
        {

        }
        public ShowTableDto(List<string> tableNames)
        {
            TableNames = tableNames;
        }
        public List<string> TableNames { get; set; }
        public string ChosenName { get; set; }
        public List<object> Values { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<string> FieldNames { get; set; }
    }
}