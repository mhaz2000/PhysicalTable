using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.DTOs
{
    //A dto for add new value to a table.
    public class AddNewValueDto
    {
        public AddNewValueDto()
        {

        }
        public AddNewValueDto(List<string> tableNames)
        {
            TableNames = tableNames;
        }
        public AddNewValueDto(List<string> fieldNames, List<string> tableNames)
        {
            TableNames = tableNames;
            FieldNames = fieldNames;
        }
        public List<string> TableNames { get; set; }
        public string ChosenName { get; set; }
        public List<string> FieldNames { get; set; }
        public string[] FieldValues { get; set; }
    }
}
