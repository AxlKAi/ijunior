using System;
using System.Linq;
using System.Collections.Generic;

namespace Example_1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Inventory
    {
        private readonly List<Cell> _cells;
        public IReadOnlyList<Cell> Cells => _cells;

        public Inventory(int maxWeigth)
        {
            _cells = new List<Cell>();
            MaxWeigth = maxWeigth;
        }

        public int MaxWeigth { get; private set; }

        public int CurrentWeight => Cells.Sum(cell => cell.Weight * cell.Count);

        public void AddItem(Item item, int count)
        {
            var newCell = new Cell(item, count);

            if (CurrentWeight + newCell.Weight > MaxWeigth)
                throw new InvalidOperationException();

            int cellIndex = _cells.FindIndex(i => i.Item == item);

            if (cellIndex == -1)
                _cells.Add(newCell);
            else
                _cells[cellIndex].Merge(newCell);
        }
    }

    public class Item
    {
        public int Weight { get; private set; }
        public string Name { get; private set; }

        public Item(string name, int weight)
        {
            Weight = weight;
            Name = name;
        }
    }

    public class Cell
    {
        public Item Item { get; private set; }
        public int Count { get; set; }

        public int Weight => Item.Weight * Count;

        public Cell(Item item, int count)
        {
            Item = item;
            Count = count;
        }

        public void Merge(Cell newCell)
        {
            if (newCell.Item != Item)
                throw new InvalidOperationException();

            Count += newCell.Count;
        }
    }

    interface IReadOnlyCell
    {
        public Item Item { get; }
        public int Count { get; set; }
    }
}


