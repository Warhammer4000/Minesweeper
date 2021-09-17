using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGameManager : MonoBehaviour
{
    public static BaseGameManager Instance;

    private MinesweeperBase _minesweeperBase;
    public IGameController GameController;

    [SerializeField] private TextMeshProUGUI MineCountText;
    [SerializeField] private TextMeshProUGUI FlagCountText;

    private int TotalFlags = 0;

    public bool IsGameOver;
    void Awake()
    {
        Instance = this;
        GameController = GetComponent<IGameController>();
    }


    void Start()
    {
        _minesweeperBase = new MinesweeperBase(12, 12, 10);
        GameController.Initialize(_minesweeperBase);
        SetMineCount();
    }

    public void GameOver()
    {
        if(IsGameOver)return;
        IsGameOver = true;
        Debug.Log("<color=red>GAME OVER</color>");
    }

    public void CascadeZeroes(int x, int y)
    {

        RevealTile(x + 1, y);

        RevealTile(x + 1, y + 1);

        RevealTile(x + 1, y - 1);


        RevealTile(x - 1, y);

        RevealTile(x - 1, y + 1);

        RevealTile(x - 1, y - 1);


        RevealTile(x, y + 1);

        RevealTile(x, y - 1);

    }

    private void RevealTile(int x, int y) => GameController.RevealTile(x,y);

    public void RevealMines()
    {
        GameController.RevealMines();
        GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetMineCount()
    {
        MineCountText.text = _minesweeperBase.TotalMines.ToString();
    }

    public void SetFlagCount(int value)
    {
        TotalFlags += value;
        FlagCountText.text = TotalFlags.ToString();
    }


}
