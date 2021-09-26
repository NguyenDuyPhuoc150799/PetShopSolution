using PetShopSolution.Data.EF;
using PetShopSolution.Data.Entities;
using PetShopSolution.ViewModels.Catalog.Newss;
using PetShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PetShopSolution.Application.Catalog.Newss
{
    public class NewsService : INewsSerivce
    {
        private readonly PetShopDbContext _context;
        public NewsService(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(NewsCreateRequest request)
        {
            var news = new News()
            {
                DateCreated = DateTime.Now,
                Tittle = request.Tittle,
                Content = request.Content,
                ImageURL = request.ImageURL
            };
            _context.Newss.Add(news);
            await _context.SaveChangesAsync();
            return news.Id;
        }

        public async Task<int> Delete(int newsId)
        {
            var news = await _context.Newss.FindAsync(newsId);
            if(news == null)
                throw new Exception($"Cannot find a news: {newsId}");
            _context.Newss.Remove(news);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<NewsViewModel>> GetAllPaging(GetAllNewsPagingRequest request)
        {
            var query = from n in _context.Newss
                        select n;
            //filter
            if (!string.IsNullOrEmpty(request.KeyWord))
                query = query.Where(x => x.Tittle.Contains(request.KeyWord) || x.Content.Contains(request.KeyWord));
            //paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new NewsViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    DateCreated = x.DateCreated,
                    Tittle = x.Tittle,
                    ImageURL = x.ImageURL
                }).ToListAsync();
            // select and projection
            var pageResult = new PagedResult<NewsViewModel>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pageResult;
        }

        public async Task<NewsViewModel> GetById(int newsId)
        {
            var news = await _context.Newss.FindAsync(newsId);
            if(news == null) throw new Exception($"Cannot find a news: {newsId}");
            var result = new NewsViewModel()
            {
               Id = news.Id,
               DateCreated = news.DateCreated,
               Tittle = news.Tittle,
               Content = news.Content,
               ImageURL = news.ImageURL
            };
            return result;
        }

        public async Task<int> Update(NewsUpdateRequest request)
        {
            var news = await _context.Newss.FindAsync(request.Id);
            if (news != null)
            {
                if (!string.IsNullOrEmpty(request.Tittle))
                    news.Tittle = request.Tittle;
                if (!string.IsNullOrEmpty(request.Content))
                    news.Content  = request.Content;
                if (!string.IsNullOrEmpty(request.ImageURL))
                    news.ImageURL = request.ImageURL;
                return await _context.SaveChangesAsync();

            }
                throw new Exception($"Cannot find a news: {request.Id}");
            
        }
    }
}
