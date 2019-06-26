using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class CardContext : DbContext
    {
        public CardContext() : base("DbConnection")
        {
        }

        public DbSet<Card> Cards { get; set; }
    }
}