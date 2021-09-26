using PetShopSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using PetShopSolution.Data.Entities;
using PetShopSolution.ViewModels.Common;
using System.Linq;
using PetShopSolution.ViewModels.Catalog.Comments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShopSolution.Application.Catalog.Comments
{
    public class CommentService : ICommentService
    {
        private readonly PetShopDbContext _context;
        public CommentService(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CommentCreateRequest request)
        {
            var comment = new Comment()
            {
                ProductId = request.ProductId,
                CreatedTime = DateTime.Now,
                UserId = request.UserId,
                Tittle = request.Tittle,
                Content = request.Content,
                Reply = request.Reply,
                Star = request.Star
            };
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment.Id;              
        }

        public async Task<int> Delete(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) throw new Exception($"Cannot find a comment: {commentId}");
            _context.Comments.Remove(comment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid userId)
        {
            var comments = await _context.Comments.Where(c => c.UserId == userId).ToListAsync();
            foreach (var item in comments)
            {
                _context.Remove(item);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<CommentViewModel>> GetAllByProductId(GetCommentPagingByProductId request)
        {
            var query = from c in _context.Comments
                        where c.ProductId == request.ProductId
                        select c;
            //paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    CreatedTime = x.CreatedTime,
                    UserId = x.UserId,
                    Tittle = x.Tittle,
                    Content = x.Content,
                    Star = x.Star,
                    Reply = x.Reply
                }).ToListAsync();
            // select and projection
            var pageResult = new PagedResult<CommentViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pageResult;
            
        }

        public async Task<PagedResult<CommentViewModel>> GetAllByUserId(GetCommentPagingByUserId request)
        {
            var query = from c in _context.Comments
                        where c.UserId == request.userId
                        select c;
            //paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    CreatedTime = x.CreatedTime,
                    UserId = x.UserId,
                    Tittle = x.Tittle,
                    Content = x.Content,
                    Star = x.Star,
                    Reply = x.Reply
                }).ToListAsync();
            // select and projection
            var pageResult = new PagedResult<CommentViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pageResult;
        }

        public async Task<CommentViewModel> GetById(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) throw new Exception($"Cannot find a comment: {commentId}");

            var result = new CommentViewModel()
            {
                Id = comment.Id,
                ProductId = comment.ProductId,
                CreatedTime = comment.CreatedTime,
                UserId = comment.UserId,
                Tittle = comment.Tittle,
                Content = comment.Content,
                Star = comment.Star,
                Reply = comment.Reply
            };
            return result;

        }

        public async Task<int> Update(CommentUpdateRequest request)
        {
            var comment = await _context.Comments.FindAsync(request.Id);
            if (comment == null) throw new Exception($"Cannot find a comment: {request.Id}");
            if(comment.UserId == request.UserId)
            {
                if (!string.IsNullOrEmpty(request.Tittle))
                    comment.Tittle = request.Tittle;
                if (!string.IsNullOrEmpty(request.Content))
                    comment.Content = request.Content;
                return await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"You cannot update this comment !");
            }
            
        }
    }
}
