﻿namespace CleanCodeTemplate.Application;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; } = null!;
    public int TotalRecords { get; set; }

}