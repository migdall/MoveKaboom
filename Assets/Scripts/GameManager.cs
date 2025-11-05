using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerPoints = 0;

    [SerializeField]
    private TextMeshProUGUI playerScoreText;
    [SerializeField]
    private TextMeshProUGUI kaboomText;
    [SerializeField]
    private TextMeshProUGUI winText;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private PlayerMovementController playerMovementController;
    [SerializeField]
    private int playerGoal;

    private bool gameOver = false;

    private void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // If not, set instance to this
            Instance = this;
        }
        else if (Instance != this)
        {
            // If instance already exists and it's not this
            // Then destroy this. This enforces the singleton pattern,
            // meaning there can only be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        kaboomText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = $"{playerPoints}";
    }

    public void AddPoint()
    {
        playerPoints++;

        if (playerPoints >= playerGoal)
        {
            gameOver = true;
            winText.gameObject.SetActive(true);
        }
    }

    public void RemovePoint()
    {
        if (playerPoints == 0)
        {
            return;
        }
        playerPoints--;
    }

    public void GetKaboomed()
    {
        playerPoints = 0;
        playerMovementController.KaboomSpinUpAnimation();

        kaboomText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true );

        gameOver = true;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
