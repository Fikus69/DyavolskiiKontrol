using System;
using System.Collections.Generic;

namespace DyavolskayaKontora.Model;

public partial class Disposal
{
    public int Id { get; set; }

    /// <summary>
    /// название объекта
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// дата покупки
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// дата утилизации
    /// </summary>
    public DateTime Date { get; set; }
}
