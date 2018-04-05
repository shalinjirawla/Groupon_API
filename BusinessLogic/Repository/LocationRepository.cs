using BusinessLogic.Interface;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class LocationRepository : ILocation
    {
        private readonly AwfirContext db;

        public LocationRepository(AwfirContext context)
        {
            this.db = context;
        }

        public List<Location> GetAllLocation()
        {
            try
            {
                var Llist = db.Locations.ToList();
                if(Llist != null)
                {
                    return Llist;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
