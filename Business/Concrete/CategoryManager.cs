using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        

        public void Delete(Category category)
        {
            var categoryToDelete = _categoryDal.GetById(category.Id);
            if (categoryToDelete != null)
                _categoryDal.Delete(categoryToDelete);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public void Add(Category category)
        {
            CategoryNameValidator(category.Name);
            CategoryWithSameNameCanNotExists(category.Name);
            _categoryDal.Add(category);
        }
        public void Update(Category category)
        {
            CategoryNameValidator(category.Name);
            CategoryWithSameNameCanNotExists(category.Name);
            _categoryDal.Update(category);
        }
        // IResult 
        private void CategoryWithSameNameCanNotExists(string categoryName)
        {
            if (_categoryDal.GetAll().FirstOrDefault(c => c.Name == categoryName) != null)
                throw new Exception("Bu isimde bir kategori zaten mevcut. Yenisini ekleyemezsin.");
        }
        private void CategoryNameValidator(string categoryName)
        {
            if (categoryName.Length < 3)
                throw new Exception("Kategori ismi 3 karakterden küçük olamaz.");
        }
    }
}
