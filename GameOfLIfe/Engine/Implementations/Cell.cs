using Engine.Interfaces;

namespace Engine.Implementations
{
    public class Cell : ICell
    {
        private struct CellSnapshot : ICellSnapshot
        {
            public string Name { get; set; }
            public Guid Guid { get; set; }
            public ICellStateSnapshot CurrentState { get; set; }
            public ICell Originator { get; set; }

            public void RestoreState()
            {
                if (Originator is Cell cell)
                {
                    Console.WriteLine("CellSnapshot - Restore");
                    cell.Guid = Guid;
                    CurrentState.RestoreState();
                }
            }
        }

        public ICellState CurrentState { get; set; } = new AliveCondition("Dead");
        public Guid Guid { get; set; }

        public Cell()
        {
            Guid = Guid.NewGuid();
        }

        public ICellSnapshot CreateSnapshot()
        {
            Console.WriteLine("ICellSnapshot");
            return new CellSnapshot()
            {
                Originator = this,
                CurrentState = CurrentState.CreateSnapshot(),
                Guid = Guid,
            };
        }
    }
}
