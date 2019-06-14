using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationProject.Models
{
    public class Name
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Please enter Student First name.")]
        public string FName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string MName { get; set; }
        public string LName { get; set; }
    }
    public class ValidationClasss {

        public int ValId { get; set; }
        public string FName { get; set; }
        public  string LName { get; set; }
        public bool IsRequired { get; set; }

    }

}