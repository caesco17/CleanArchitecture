using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    internal class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Video> GetVideoByName(string videoName)
        {
            return await _context.Videos.FirstOrDefaultAsync(v => v.Name == videoName);
        }

        public async Task<IEnumerable<Video>> GetVideoByUserame(string userName)
        {
            return await _context.Videos.Where(v => v.CreatedBy == userName).ToListAsync();
        }
    } 
}
