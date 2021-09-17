using UnityEngine;

public class Minesweeper3D : BaseController, IGameController
{
    [SerializeField] private GameObject TilePrefab3D;

    public void Initialize(MinesweeperBase minesweeper)
    {
        var x = minesweeper.X;
        var y = minesweeper.Y;
        for (var i = 1; i < x - 1; i++)
        for (var j = 1; j < y - 1; j++)
        {
            var value = minesweeper.Minefield[i, j];
            var tile = Instantiate(TilePrefab3D, new Vector3(i, 0, j), Quaternion.identity,MineField);
            tile.GetComponent<BaseTile>().Initialize(i, j, value);
            Tiles.Add(tile.GetComponent<BaseTile>());
        }
    }
}