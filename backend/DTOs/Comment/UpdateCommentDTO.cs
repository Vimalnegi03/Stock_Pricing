using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs.Comment
{
    public class UpdateCommentDTo
    {
          [MinLength(3, ErrorMessage = "Title must be of 3 character")]
        [MaxLength(280, ErrorMessage = "Title cant be over 280 characters")]
          public string? Title { get; set; } 
          
          
          [MinLength(3, ErrorMessage = "Content must be of 3 character")]
        [MaxLength(280, ErrorMessage = "Content cant be over 280 characters")]

        public string? Content { get; set; } 
    }
}