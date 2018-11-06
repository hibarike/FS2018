using System;
using System.Collections.Generic;
using System.Text;

//used for calculating tips

namespace TipCalc.Services
{
    public interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
    }
}
