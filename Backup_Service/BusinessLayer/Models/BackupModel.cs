﻿namespace BusinessLayer.Models;

public class BackupModel
{
    public int Id { get; set; }
    public int IdStorage { get; set; }
    public int TariffType { get; set; }
    public string Name { get; set; }
    public DateTime CreationTime { get; set; }
    public decimal Size { get; set; }
    public int IdAccount { get; set; }
}