using Physical.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.Common.TypeConvertion
{
    public class TypeConvert
    {
        public static string[] TypeExtraction(FieldTypes[] fieldTypes)
        {
            string[] types = new string[fieldTypes.Length];

            for (int i = 0; i < fieldTypes.Length; i++)
            {
                switch (fieldTypes[i])
                {
                    case FieldTypes.@int:
                        types[i] = "int";
                        break;
                    case FieldTypes.@string:
                        types[i] = "nvarchar(Max)";
                        break;
                    case FieldTypes.@char:
                        types[i] = "char";
                        break;
                    case FieldTypes.@float:
                        types[i] = "float";
                        break;
                    case FieldTypes.@double:
                        types[i] = "real";
                        break;
                    case FieldTypes.DateTime:
                        types[i] = "DateTime";
                        break;
                }
            }
            return types;
        }
    }
}