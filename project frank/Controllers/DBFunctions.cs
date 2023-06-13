using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_frank.Controllers
{
    public class DBFunctions
    {
        protected songsDataContext db { get; set; }
        public DBFunctions()
        {
            db = new songsDataContext();
        }

        public List<Table> getSongs()
        {
            List<Table> list = (from S in db.Tables select S).ToList();
            List<Table> returnList = new List<Table>();

            foreach (var song in list)
            {
                if (song.Fav == 1)
                {
                    returnList.Add(song);
                }
            }
            return returnList;
        }

        public List<Table> getAllSongs()
        {
            return (from i in db.Tables select i).ToList();
        }

        public bool CheckLogin(string Password)
        {
            var check = (from u in db.Users where u.Password == Password select u);
            if (check.Any())
                return true;
            return false;
        }

        public bool addSong(int number, string Band, string Song, int Fav)
        {
            try
            {
                Table newSong = new Table
                {
                    Fav = Fav,
                    Nummer = number,
                    Band = Band,
                    Liedje = Song
                };
                db.Tables.InsertOnSubmit(newSong);
                db.SubmitChanges();
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public bool delSong(int ID)
        {
            var del = db.Tables.Single(u => u.ID == ID);
            if (del == null) return false;
            db.Tables.DeleteOnSubmit(del);
            db.SubmitChanges();
            return true;
        }

        public List<Table> preEditSong(int ID)
        {
            return (from u in db.Tables where  u.ID == ID select u).ToList();
        }
    }
}