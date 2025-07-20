using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject main;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject player;
    public void Play()
    {
       main.SetActive(false);
       gameOver.SetActive(false);
       Instantiate(player);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void MainMenu()
    {
        main.SetActive(true);
        gameOver.SetActive(false);
    }
}
