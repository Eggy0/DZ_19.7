using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerTurret : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private int score = 0;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text scoreText;

    private (Collider player, Collider ammo) colliders;

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
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

    public void GainPoints(int points)
    {
        score += points;
        scoreText.text = $"Score: {score}";
    }

    public int GetScore()
    {
        return score;
    }
}
