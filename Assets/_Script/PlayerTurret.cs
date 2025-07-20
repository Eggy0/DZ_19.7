using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerTurret : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text scoreText;

    private (Collider player, Collider ammo) colliders;
    internal int score = 0;

    private int health;
    void Start()
    {
        
        colliders.player = GetComponentInChildren<Collider>();
        scoreText.text = $"Score: {score}";
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0,-speed * Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Bullet newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        colliders.ammo = newBullet.GetComponent<Collider>();
        try
        {
            Physics.IgnoreCollision(colliders.player, colliders.ammo);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Something went wrong: {ex}");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= Mathf.Abs(damage); //Force it to always be negative
        healthBar.fillAmount = ((float)health / (float)maxHealth);
        if (health <= 0)
        {
            //Trigger game over
            Destroy(gameObject);
        }
    }

    public void GetPoints(int points)
    {
        Debug.Log($"scoreText.text {scoreText.text}");
        Debug.Log($"Current score: {score}");
        score += points;
        Debug.Log($"Scored: {score}");
        scoreText.text = $"Score: {score}";
        Debug.Log($"scoreText.text {scoreText.text}");
    }
}
