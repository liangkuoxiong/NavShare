using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavShare
{
    public class BLL
    {
        public static void InsertNav(Nav entity)
        {
            entity.VisitTime = DateTime.Now;
            using (NavShareEntities db = new NavShareEntities())
            {
                db.Nav.Add(entity);
                db.SaveChanges();
            }
        }
        public static List<Nav> GetNavList()
        {
            using (NavShareEntities db = new NavShareEntities())
            {
                return db.Nav.ToList();
            }
        }
        public static void InsertShare(Share entity)
        {
            entity.ShareTime = DateTime.Now;
            using (NavShareEntities db = new NavShareEntities())
            {
                db.Share.Add(entity);
                db.SaveChanges();
            }
        }
        public static List<Share> GetShareList()
        {
            using (NavShareEntities db = new NavShareEntities())
            {
                return db.Share.ToList();
            }
        }
    }
}