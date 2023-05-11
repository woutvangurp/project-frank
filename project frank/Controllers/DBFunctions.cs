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
            return (from S in db.Tables select S).ToList();
        }
    }
}