using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unlogy.Data;
using Unlogy.Dto;


namespace Unlogy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryWithCourseCountDTO>>> GetCategories()
        {
            var categories = await _context.Categories.Select(c => new CategoryWithCourseCountDTO
            {
                Name = c.Name,
                Icon = c.Icon,
                CourseCount =_context.Courses.Count(course => course.CategoryId == c.Id)
            }).ToListAsync();
            return Ok(categories);    
        }
           }
}
