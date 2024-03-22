﻿namespace CleanCodeTemplate.Application;

public class CustomerByIdResponseDTO
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Address { get; set; }
    public string? City { get; set; }
    public int State { get; set; }
}
