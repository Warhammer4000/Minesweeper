

public interface IGameController
{
      void Initialize(MinesweeperBase minesweeper);

      void RevealTile(int x, int y);

      void RevealMines();
}