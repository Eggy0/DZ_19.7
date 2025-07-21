using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static PlayerTurret player;

    [SerializeField] private GameObject main;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Vector3[] spawnPosition;
    [SerializeField] private float spawnDelay;

    private void Awake()
    {
        instance = this;
    }
    private void RegisterPlayer(PlayerTurret registerObj)
    {
        player = registerObj;
    }
    private IEnumerator SpawnEnemies(float delay)
    {
        yield return new WaitForSeconds(delay);
        int randomIndex = UnityEngine.Random.Range(0, spawnPosition.Length);
        Instantiate(enemy, spawnPosition[randomIndex], Quaternion.identity);
        yield return SpawnEnemies(delay);
    }
    public void Play()
    {
        if (player != null)
        {
            Debug.Log("The player already exists! Re-instantiating...");
            Destroy(player);
        }
       main.SetActive(false);
       gameOver.SetActive(false);
       GameObject newPlayer = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
       newPlayer.name = "The PLAYER";
       PlayerTurret playerInstance = newPlayer.GetComponent<PlayerTurret>();
       RegisterPlayer(playerInstance);
       StartCoroutine(SpawnEnemies(spawnDelay));
    }

    public void GameOver()
    {
        StopAllCoroutines();
        gameOver.SetActive(true);
    }
    public void MainMenu()
    {
        StopAllCoroutines();
        main.SetActive(true);
        gameOver.SetActive(false);
    }
}
