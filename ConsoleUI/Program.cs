// See https://aka.ms/new-console-template for more information
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities;


ICategoryService categoryService = new CategoryManager(new InMemoryCategoryDal());

var categoryToAdd = new Category() { Id = 2, Name = "Sebze" };
categoryService.Add(new Category() { Id = 1, Name = "Meyve" });
categoryService.Add(categoryToAdd);

List<Category> allCategories = categoryService.GetAll();

categoryService.Update(new Category() { Id = 2, Name = "Bakliyat" });

categoryService.Delete(new Category() { Id = 2 });

foreach (Category category in allCategories)
{
    Console.WriteLine($"{category.Id} - {category.Name}");
}