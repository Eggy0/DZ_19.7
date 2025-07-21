using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;

public class MainMenuHighScore : MonoBehaviour
{
    private string SCORE_KEY = "_scoreKey";
    private TMP_Text text;
    void OnEnable()
    {
        text = GetComponent<TMP_Text>();
        int bestScore = PlayerPrefs.GetInt(SCORE_KEY);
        text.text = $"Best score: {bestScore}";
    }
}

