using Microsoft.EntityFrameworkCore;
using Tabu.DAL;
using Tabu.DTOs.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class LanguageService(TabuDbContext _context) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            await _context.AddAsync(new Entities.Language
            {
                Code = dto.Code,
                Icon = dto.Icon,
                Name = dto.Name
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGeetDto>> GetAllAsync()
        {
            return await _context.Languages.Select(x => new LanguageGeetDto
            {
                Code = x.Code,
                Icon = x.Icon,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task DeleteAsync(string? code)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x => x.Code == code);
            if (data == null)
            {
                _context.Languages.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(string code, LanguageUpdateDto dto)
        {
            var data = await _context.Languages.FirstOrDefaultAsync(x=>x.Code == code);
            if(data != null)
            {
                data.Name = dto.Name;
                data.Icon = dto.Icon;
                await _context.SaveChangesAsync();
            }
        }
    }
}
