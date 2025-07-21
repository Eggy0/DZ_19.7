using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public PlayerTurret target => GameManager.player;
    private TMP_Text text;
    private string SCORE_KEY = "_scoreKey";
    [SerializeField] private GameObject newBest;
    private void OnEnable()
    {
        text = GetComponent<TMP_Text>();
        int bestScore = PlayerPrefs.GetInt(SCORE_KEY, 0);
        int currentScore = target.GetScore();
        if (bestScore < currentScore) 
        { 
            bestScore = currentScore;
            PlayerPrefs.SetInt(SCORE_KEY, bestScore);
            PlayerPrefs.Save();
            Debug.Log("Highscore");
            newBest.SetActive(true);
        }
        else
        {
            {
                newBest.SetActive(false);
            }
        }
            text.text = $"Your score: \r\n{currentScore}\r\nBest score: \r\n{bestScore}";
    }
}
