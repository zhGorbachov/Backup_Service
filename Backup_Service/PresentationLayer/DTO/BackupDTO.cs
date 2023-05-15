﻿namespace DataLayer.DTO;

public class BackupDTO
{
    public int Id { get; set; }
    public int IdStorage { get; set; }
    public string TarrifType { get; set; }
    public string Name { get; set; }
    public DateTime CreationTime { get; set; }
    public decimal Size { get; set; }
}