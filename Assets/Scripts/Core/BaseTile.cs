using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseTile : MonoBehaviour
{

    public int X { get; private set; }
    public int Y { get; private set; }
    public string Value { get; private set; }
    protected bool Revealed;



    public void Initialize(int x, int y, string value)
    {
        if (value == null || value == "0") value = "";
        X = x;
        Y = y;
        Value = value;
    }


    public void OnLeftButtonClick()
    {
        if (Revealed) return;
        Revealed = true;
        if (Value == MinesweeperBase.mine)
        {
            MineTileClicked();
            BaseGameManager.Instance.RevealMines();
            return;
        }

        if (string.IsNullOrEmpty(Value))
        {
            ZeroTileClicked();
            BaseGameManager.Instance.CascadeZeroes(X, Y);
            return;
        }

        HintTileClicked();
    }

    protected abstract void OnFlag();
    protected abstract void MineTileClicked();
    protected abstract void ZeroTileClicked();
    protected abstract void HintTileClicked();


}
