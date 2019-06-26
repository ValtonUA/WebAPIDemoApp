using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class Card
    {
        public int CardId { get; set; }

        public string MarketName { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}