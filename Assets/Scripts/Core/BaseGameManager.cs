using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGameManager : MonoBehaviour
{
    public static BaseGameManager Instance;

    public MinesweeperBase MinesweeperBase { get; set; }
    public IGameController GameController;

    [SerializeField] private TextMeshProUGUI MineCountText;
    [SerializeField] private TextMeshProUGUI FlagCountText;

    [SerializeField] private GameObject GameStatus;


    private int TotalFlags = 0;

    public bool IsGameOver;
    void Awake()
    {
        Instance = this;
        GameController = GetComponent<IGameController>();
    }


    void Start()
    {
        MinesweeperBase = new MinesweeperBase(12, 12, 10);
        GameController.Initialize(MinesweeperBase);
        SetMineCount();
    }

    public void GameOver()
    {
        if(IsGameOver)return;
        IsGameOver = true;
        Debug.Log("<color=red>GAME OVER</color>");
    }

    public void GameWon()
    {
        if(IsGameOver)return;
        IsGameOver = true;
        GameStatus.SetActive(true);
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

    private void RevealTile(int x, int y) => GameController.RevealTile(x, y);

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
        MineCountText.text = MinesweeperBase.TotalMines.ToString();
    }

    public void SetFlagCount(int value)
    {
        TotalFlags += value;
        FlagCountText.text = TotalFlags.ToString();
    }


}
