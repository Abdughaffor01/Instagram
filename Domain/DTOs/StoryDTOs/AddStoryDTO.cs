using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.StoryDTOs
{
    public class AddStoryDTO
    {
        public string UserId { get; set; }
        public int? PostId { get; set; }
        public IFormFile? File { get; set; }
    }
}
