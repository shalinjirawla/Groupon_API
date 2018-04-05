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
    public class CategoryRepository : ICategory
    {
        private readonly AwfirContext db;

        public CategoryRepository(AwfirContext context)
        {
            db = context;
        }

        public List<Category> GetAllCategory()
        {
            try
            {
                var Llist = db.Categorys.ToList();
                if (Llist != null)
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
