using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public enum Gender
    {
        Mand,
        Kvinde,
        Andet
    }
    public class User
    {
        public int ID { get; set; }
        public string name { get;set; }
        public int age { get; set; }
        public Gender gender { get; set; }
    }
}
