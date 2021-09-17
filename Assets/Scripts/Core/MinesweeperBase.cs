

using UnityEngine;

public class MinesweeperBase
{

    public static readonly string mine = "M";


    public string[,] Minefield { get; }
    public int X { get; }
    public int Y { get; }
    public int TotalMines { get; }


    public MinesweeperBase(int x=10,int y=10,int totalMines=10)
    {
        X = x;
        Y = y;
        TotalMines = totalMines;
        Minefield = new string[x, y];

        InitializeMines();
        SetHintsBruteForce();
    }


    private void InitializeMines()
    {
        for (int i = 0; i < TotalMines; i++)
        {
            int randomX = Random.Range(1, X-1);
            int randomY = Random.Range(1, Y-1);
            Minefield[randomX,randomY] = mine;
        }
    }

    private void SetHintsBruteForce()
    {
        for (int i = 1; i < X-1; i++)
        {
            for (int j = 1; j < Y-1; j++)
            {
                if (Minefield[i, j] == mine) continue;
                Minefield[i, j] = GetAdjacentMineCount(i, j).ToString();
            }
        }
    }

    private int GetAdjacentMineCount(int x, int y)
    {
        int mineCount = 0;
        if (Minefield[x+1, y] == mine)
        {
            mineCount++;
        }

        if (Minefield[x + 1, y+1] == mine)
        {
            mineCount++;
        }

        if (Minefield[x + 1, y-1] == mine)
        {
            mineCount++;
        }

        if (Minefield[x , y+1] == mine)
        {
            mineCount++;
        }

        if (Minefield[x, y - 1] == mine)
        {
            mineCount++;
        }

        if (Minefield[x - 1, y] == mine)
        {
            mineCount++;
        }

        if (Minefield[x - 1, y + 1] == mine)
        {
            mineCount++;
        }

        if (Minefield[x - 1, y - 1] == mine)
        {
            mineCount++;
        }

        return mineCount;
    }







}
