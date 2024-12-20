using Tabu.DTOs.Languages;

namespace Tabu.Services.Abstracts
{
    public interface ILanguageService
    {
        Task CreateAsync(LanguageCreateDto dto);
        Task<IEnumerable<LanguageGeetDto>> GetAllAsync();
        Task DeleteAsync(string? code);
        Task UpdateAsync(string? code , LanguageUpdateDto dto);
    }
}
