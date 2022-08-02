using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class MemoryHandler
    {
        private readonly Stack<double> _memory;

        public double[] Memory { get => _memory.ToArray(); }
        
        public MemoryHandler()
        {
            _memory = new Stack<double>();
        }

        public void MemorySave(double value)
        {
            _memory.Push(value);
        }
        
        public void MemoryClear()
        {
            _memory.Clear();
        }
        
        public double MemoryRecall()
        {
            return _memory.Peek();
        }
        
        public void MemoryModification(double value)
        {
            if(_memory.Count == 0)
            {
                _memory.Push(value);
            }
            else
            {
                _memory.Push(_memory.Pop() + value);
            }
        }
    }
}