using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileLogic2D : BaseTile, IPointerDownHandler
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
   
  
    protected override void OnFlag()
    {
        _button.image.color = _button.image.color == Color.blue ? Color.white : Color.blue;
    }

    protected override void MineTileClicked()
    {
        _button.image.color = Color.red;
        _text.color = Color.white;
        _text.text = MinesweeperBase.mine;
    }

    protected override void ZeroTileClicked()
    {
        _button.image.color = Color.gray;
    }

    protected override void HintTileClicked()
    {
        _button.image.color = Color.black;
        _text.color = Color.green;
        _text.text = Value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (BaseGameManager.Instance.IsGameOver) return;
        if (Revealed) return;
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftButtonClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnFlag();
        }
    }
}
