using System;
using System.Collections.Generic;

namespace TaxiDispatcher4;

public partial class TaxiDriver
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CarNumber { get; set; } = null!;

    public string CarClass { get; set; } = null!;
}
