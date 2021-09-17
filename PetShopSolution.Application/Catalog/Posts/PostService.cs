using Microsoft.EntityFrameworkCore;
using PetShopSolution.Data.EF;
using PetShopSolution.Data.Entities;
using PetShopSolution.ViewModels.Catalog.Posts;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Catalog.Posts
{
    public class PostService : IPostService
    {
        private readonly PetShopDbContext _context;
        public PostService(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(PostCreateRequest request)
        {
            var post = new Post()
            {
                UserId = request.UserId,
                ViewCount = 0,
                Tittle = request.Tittle,
                CreatedTime = DateTime.Now,
                Content = request.Content,
                Status = request.Status,
                ImageURL = request.ImageURL
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.Id;
        }

        public async Task<int> Delete(int postID)
        {
            var post = await _context.Posts.FindAsync(postID);
            if (post == null) throw new Exception($"Cannot find a post: {postID}");
            _context.Posts.Remove(post);
            return  await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<PostViewModel>> GetAllPostByUserId(GetPostPagingByUserId request)
        {
            var query = from p in _context.Posts
                        where p.UserId == request.userId
                        select p;
            var user = await _context.AppUsers.FindAsync(request.userId);
            //paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PostViewModel()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Tittle = x.Tittle,
                    Content = x.Content,
                    ViewCount = x.ViewCount,
                    CreatedTime = x.CreatedTime,
                    ImageURL = x.ImageURL,
                    UserName = user.UserName,
                }).ToListAsync();
            // select and projection
            var pageResult = new PagedResult<PostViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize               
            };
            return pageResult;
          

        }

        public async Task<PostViewModel> GetPostById(int postID)
        {
            var post = await _context.Posts.FindAsync(postID);
            if (post == null) throw new Exception($"Cannot find a post: {postID}");
            var user = await _context.AppUsers.FindAsync(post.UserId);
            var postViewModel = new PostViewModel()
            {
                Id = post.Id,
                UserId = post.UserId,
                Tittle = post.Tittle,
                Content = post.Content,
                ViewCount = post.ViewCount,
                CreatedTime = post.CreatedTime,
                ImageURL = post.ImageURL,
                UserName = user.UserName
            };
            return postViewModel;


        }

        public async Task<int> Update(PostUpdateRequest request)
        {
            var post = await _context.Posts.FindAsync(request.Id);
            if(post ==null) throw new Exception($"Cannot find a post: {request.Id}");
            else
            {
                post.Tittle = request.Tittle;
                post.Content = request.Content;
                post.Status = request.Status;
                post.ImageURL = request.ImageURL;
            }
            return await _context.SaveChangesAsync() ;
        }
    }
}
