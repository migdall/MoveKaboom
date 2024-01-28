using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerPoints = 0;

    [SerializeField]
    private TextMeshProUGUI playerScoreText;

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
    }
}
