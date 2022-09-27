using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCategoryDal : ICategoryDal
    {
        private List<Category> categories = new();
        public void Add(Category category)
        {
            categories.Add(category);
        }
        public void Delete(Category category)
        {
            categories.Remove(category);
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public Category GetById(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            Category categoryToUpdate = categories.FirstOrDefault(c => c.Id == category.Id);
            categoryToUpdate.Name = category.Name;
        }
    }
}
