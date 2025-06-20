﻿using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service
{
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record ItemDtoOut(string Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    
    public record CreatedItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal Price);

    public record UpdateItemDto([Required] string Name, string Description, [Range(0, 1000)] decimal Price);
}
