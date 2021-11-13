using Microsoft.EntityFrameworkCore;
using PostServiceBackendApi.Data;
using PostServiceBackendApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServiceBackendApi.Repositories
{
    public class PostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddPostAsync(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdatePost(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
