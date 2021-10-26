using System.ComponentModel.DataAnnotations;

namespace mycrud.Models
{

    public class Person
    {

        [Key]
        public int Id { get; set; }

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string role { get; set; }
        public string country { get; set; }
    }

}