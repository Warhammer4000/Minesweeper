using TMPro;
using UnityEngine;

public class TileLogic3D : BaseTile
{
    [SerializeField] private GameObject Flag;
    [SerializeField] private GameObject Zero;
    [SerializeField] private GameObject Hint;
    [SerializeField] private GameObject Mine;

    protected override void OnFlag()
    {
        
        if (Flag.activeInHierarchy)
        {
            Flag.SetActive(false);
            BaseGameManager.Instance.SetFlagCount(-1);
        }
        else
        {
            Flag.SetActive(true);
            BaseGameManager.Instance.SetFlagCount(1);
        }
    }

    protected override void MineTileClicked()
    {
        HideFlag();
        Mine.SetActive(true);
    }

    protected override void ZeroTileClicked()
    {
        HideFlag();
        Zero.SetActive(true);
    }

    protected override void HintTileClicked()
    {
        HideFlag();
        Hint.SetActive(true);
        Hint.GetComponentInChildren<TextMeshPro>().text = Value;
    }

    private void HideFlag()
    {
        if (Flag.activeInHierarchy)
        {
            Flag.SetActive(false);
            BaseGameManager.Instance.SetFlagCount(-1);
        }
    }


    private void OnMouseOver()
    {
        if (BaseGameManager.Instance.IsGameOver) return;
        if (Revealed) return;
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftButtonClick();
            return;
        }

        if (Input.GetMouseButtonDown(1)) OnFlag();
    }
}