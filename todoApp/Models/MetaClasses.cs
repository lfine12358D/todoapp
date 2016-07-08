using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace todoApp.Models
{
    
    public class ToDoMetaClass
    {
        [Required]
        [Display(Name = "ToDo Description")]
        public string toDoDesc { get; set; }
    }
}