using Domain.Enums;

namespace Domain.Models;
public class IndividualSearchCriteria
{
    public string? QuickSearch { get; set; } // For name, surname, or personal number (LIKE search)
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PersonalNumber { get; set; }
    public GenderType? Gender { get; set; }
    public int? CityId { get; set; }
    public DateOnly? DateOfBirthFrom { get; set; }
    public DateOnly? DateOfBirthTo { get; set; }
    public int PageNumber { get; set; } = 1; // Default to page 1
    public int PageSize { get; set; } = 10; // Default page size
}