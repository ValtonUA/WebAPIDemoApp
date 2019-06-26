using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }
    }
}