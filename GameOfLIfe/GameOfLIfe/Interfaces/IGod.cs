﻿namespace GameOfLIfe.Interfaces
{
    public interface IGod
    {
        ICellState GetNextCellState(ICell cell, IEnumerable<ICell> neigthbords);
        ICellState GetRandomCellState();
    }
}
