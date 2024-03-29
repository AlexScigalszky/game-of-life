﻿using Engine.Interfaces;

namespace Engine.Implementations
{
    public class Cell : ICell
    {
        public ICellState CurrentState { get; set; } = new AliveCondition("Dead");

        public Guid Guid { get; private set; }

        public Cell()
        {
            Guid = Guid.NewGuid();
        }
    }
}
