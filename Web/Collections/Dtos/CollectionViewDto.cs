using Collections.Models;
using Shared.Models;

namespace Collections.Dtos;

public class CollectionViewDto
{
    public CollectionViewDto(CollectionModel collection)
    {
        Id = collection.Id;
        Name = collection.Name;
        CoverPath1 = collection.CoverPath1;
        CoverPath2 = collection.CoverPath2;
        CoverPath3 = collection.CoverPath3;
        Creator = collection.Creator;
        NumberOfFollowers = collection.NumberOfFollowers;
        PublishedDate = collection.PublishedDate;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? CoverPath1 { get; set; }
    public string? CoverPath2 { get; set; }
    public string? CoverPath3 { get; set; }
    public ProfileModel? Creator { get; set; }
    public ulong NumberOfFollowers { get; set; }
    public DateTime PublishedDate { get; set; }
}