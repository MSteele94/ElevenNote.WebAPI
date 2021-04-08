using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        // private readonly List<Note> _notes;
        private readonly Guid _tableId;

        public CategoryService(Guid tableId)
        {
            _tableId = tableId;
        }
        public bool CreateCategory(CategoryCreate model)
        {
            var entity = new Category()
            {
                TableId = _tableId,
                Name = model.Name,
                
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id && e.TableId == _tableId);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        Name = entity.Name
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == model.CategoryId && e.TableId == _tableId);
                entity.CategoryId = entity.CategoryId; 
                entity.Name = entity.Name;
                return ctx.SaveChanges() == 1;
            }    
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Where(e => e.TableId == _tableId)
                    .Select(
                        e =>
                        new CategoryListItem 
                        { 
                            CategoryId = e.CategoryId,
                            Name = e.Name
                        });
                return query.ToArray();
            }
        }
        public bool DeleteCategory (int categoryId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == categoryId && e.TableId == _tableId);
                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
