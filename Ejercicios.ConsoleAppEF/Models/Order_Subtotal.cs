using System;
using System.Collections.Generic;

namespace Ejercicios.ConsoleAppEF.Models;

public partial class Order_Subtotal
{
    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
