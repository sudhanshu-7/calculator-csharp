using System;

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