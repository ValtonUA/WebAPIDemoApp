using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    public class CardRepository : IRepository<Card>
    {
        CardContext db;
        ILogger logger;

        public CardRepository(ILogger logger)
        {
            db = new CardContext();
            this.logger = logger;
        }

        public void Delete(int id)
        {
            var card = db.Cards.Find(id);
            if (card != null)
                db.Cards.Remove(card);

            logger.Log($"Delete request with id: '{id}'");
        }

        public Card Get(int id)
        {
            logger.Log($"Get request with id: '{id}'");
            return db.Cards.SingleOrDefault(i => i.CardId == id);
        }

        public List<Card> GetAll()
        {
            logger.Log("GetAll request");
            return db.Cards.ToList();
        }

        public void Post(Card item)
        {
            db.Cards.Add(item);
            logger.Log($"Post request with id: '{item.CardId}'");
        }

        public void Put(Card item)
        {
            var card = db.Cards.Find(item.CardId);
            if (card != null)
            {
                card.MarketName = item.MarketName;
                card.UserId = item.UserId;
                card.User = item.User;
            }
            logger.Log($"Put request with id: '{item.CardId}'");
        }

        public void Save()
        {
            db.SaveChanges();
            logger.Log($"Save request");
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}