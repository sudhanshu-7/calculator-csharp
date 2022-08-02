using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public interface IMemoryHandler
    {
        void MemorySave(double value);

        void MemoryClear();

        double MemoryRecall();

        void MemoryModification(double value);
    }
}