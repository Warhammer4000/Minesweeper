using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] protected List<BaseTile> Tiles;
    [SerializeField] protected Transform MineField;
    public void RevealTile(int x, int y)
    {
        StartCoroutine(DelayedReveal(x,y));
    }

    public void RevealMines()
    {
        StartCoroutine(DelayedExplosion());
    }

    private IEnumerator DelayedExplosion()
    {
        var mineTiles = Tiles.FindAll(r => r.Value == MinesweeperBase.mine);
        foreach (var mineTile in mineTiles)
        {
           
            yield return new WaitForSeconds(0.3f);
            mineTile.OnLeftButtonClick();
            
        }
    }

    private IEnumerator DelayedReveal(int x,int y)
    {
        var tile = Tiles.Find(r => r.X == x && r.Y == y);
        if (tile == null) yield break;
        yield return new WaitForSeconds(0.05f);
        tile.OnLeftButtonClick();
       
    }

    void LateUpdate()
    {
        CheckVictory();
    }

    private void CheckVictory()
    {
        int nonRevealedTiles = Tiles.Count(r =>r.Revealed!=true);
        if (nonRevealedTiles == BaseGameManager.Instance.MinesweeperBase.TotalMines)
        {
            BaseGameManager.Instance.GameWon();
        }

    }


}
