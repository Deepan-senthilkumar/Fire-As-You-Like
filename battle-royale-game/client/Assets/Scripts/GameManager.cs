using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int playerScore;
    private bool isMatchActive;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerScore = 0;
        isMatchActive = false;
    }

    public void StartMatch()
    {
        isMatchActive = true;
        // Additional logic to initialize the match
    }

    public void EndMatch()
    {
        isMatchActive = false;
        // Additional logic to handle end of match
    }

    public void AddScore(int score)
    {
        playerScore += score;
        // Update UI or other systems as needed
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public bool IsMatchActive()
    {
        return isMatchActive;
    }
}