using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Data.Models
{
    //For logging table creating.
    public class Log
    {
        public Log(string name)
        {
            LogID = Guid.NewGuid();
            LogTime = DateTime.Now;
            TableName = name;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid LogID { get; set; }
        public DateTime LogTime { get; set; }
        public string TableName { get; set; }
    }
}