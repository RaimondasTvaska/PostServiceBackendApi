using PostServiceBackendApi.Entities;
using PostServiceBackendApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackendApi.Services
{
    public class PostService
    {
        private PostRepository _postRepository;

        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<int> AddPostAsync(Post post)
        {

            var entity = new Post()
            {
                Town = post.Town,
                Capacity = post.Capacity,
                PostCode = post.PostCode
            };
            await _postRepository.AddPostAsync(entity);
            return entity.Id;
        }
        public async Task<List<Post>> GetAllAsync()
        {
            var postEntities = await _postRepository.GetAllPostsAsync();

            return postEntities.ToList();
        }
        public async Task<Post> GetByIdAsync(int id)
        {
            return await _postRepository.GetPostByIdAsync(id);
        }
        public async Task UpdatePostAsync(int id, Post post)
        {
            var entity = new Post()
            {
                Id = post.Id,
                Town = post.Town,
                Capacity = post.Capacity,
                PostCode = post.PostCode
            };
            if (id != post.Id)
            {
                throw new ArgumentException("Post not found");
            }
            await _postRepository.UpdatePost(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
