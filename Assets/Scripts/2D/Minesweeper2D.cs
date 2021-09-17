
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class Minesweeper2D : BaseController, IGameController
{
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private GameObject _buttonPrefab;




    public void Initialize(MinesweeperBase minesweeper)
    {
        _gridLayout.constraintCount = minesweeper.X - 2;

        var x = minesweeper.X;
        var y = minesweeper.Y;
        for (var i = 1; i < x - 1; i++)
        for (var j = 1; j < y - 1; j++)
        {
            var value = minesweeper.Minefield[i, j];
            var tile = Instantiate(_buttonPrefab, MineField);
            tile.GetComponent<BaseTile>().Initialize(i, j, value);
            Tiles.Add(tile.GetComponent<BaseTile>());
        }
    }

  

}
