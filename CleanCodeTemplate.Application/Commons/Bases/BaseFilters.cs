﻿namespace CleanCodeTemplate.Application;

public class BaseFilters : BasePagination
{
    public int? NumFilter { get; set; }
    public string? TextFilter { get; set; }
    public int? StateFilter { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }


}
