using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategoryRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Catgories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = db.Catgories.Find(categoryId);
            if (category == null) return;

            db.Catgories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Catgories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.Catgories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var cat = db.Catgories.Find(category.CategoryId);
            cat.Name = category.Name;
            cat.Description = category.Description;
        }
    }
}
