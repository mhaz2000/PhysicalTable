using Physical.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Physical.DTOs
{
    //This Dto is used for create table structures.
    public class TableStructionDto
    {
        [Display(Name = "تعداد فیلد ها")]
        public int FieldNumber { get; set; }
        [Display(Name = "نام جدول")]
        public string tableName { get; set; }
        public string Message { get; set; }
        [Display(Name = "نام فیلد")]
        public string[] FieldNames { get; set; }
        [Display(Name = "نوع فیلد")]
        public FieldTypes[] FieldTypes { get; set; }
    }
}