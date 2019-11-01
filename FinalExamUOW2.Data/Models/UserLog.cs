using System;
using System.ComponentModel.DataAnnotations;

namespace FinalExamUOW2.Data.Models
{
    public class UserLog
    {
        [Key]   
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
