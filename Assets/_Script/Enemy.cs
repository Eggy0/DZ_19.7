using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public PlayerTurret target => GameManager.player;
    [SerializeField] private int maxHealth = 20;
    //[SerializeField] private PlayerTurret target;
    [SerializeField] private float step;
    [SerializeField] private Image healthBar;

    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            Debug.Log("Enemy collision with bullet");
            TakeDamage(5);
            Destroy(bullet);
        }
        if (collision.gameObject.TryGetComponent(out PlayerTurret player))
        {
            player.TakeDamage(5);
            Debug.Log("Player takes damage");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= Mathf.Abs(damage); //Force it to always be negative
        healthBar.fillAmount = ((float)health / (float)maxHealth);
        if (health <= 0) 
        {
            target.GainPoints(1);
            Destroy(gameObject);
        }
    }
}
