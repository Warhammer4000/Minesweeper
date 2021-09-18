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


    public void Initialize(GameMode mode)
    {
        MinesweeperBase = new MinesweeperBase(mode.x,mode.y,mode.Mines);
        GameController.Initialize(MinesweeperBase);
        SetMineCount();
        SetCamera();
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


    private void SetCamera()
    {
       
        var cam = Camera.main;
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (new Vector3(-40,5,-25) + new Vector3(MinesweeperBase.X+2,5,MinesweeperBase.Y+2)) / 2f;

        // Distance between objects
        float distance = (new Vector3(-40, 5,-25) - new Vector3(MinesweeperBase.X+2,5, MinesweeperBase.Y+2)).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }


}
