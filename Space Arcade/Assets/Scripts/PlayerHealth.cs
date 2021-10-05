using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject tint;
    public GameObject gameOverScreen;
    public GameObject[] hearts;
    private int health = 0;
    public int startHealth = 3;
    private AudioManager _audioManager;
    public GameObject playerExplosion;
    void Start()
    {
        ApplyHealth(startHealth);
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void ApplyHealth(int amount)
    {
        health += amount;
        if (health > 3) health = 3;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (!hearts[i].activeSelf)
            {
                hearts[i].SetActive(true);
                if (i == amount) break;
            }
        }
    }

    public void Hit()
    {
        health--;
        for (int i = hearts.Length - 1; i >= 0; i--)
        {
            if (hearts[i].activeSelf)
            {
                hearts[i].SetActive(false);
                break;
            }
        }
        
        if (health <= 0) OnDeath();
    }
    public void OnDeath()
    {
        Instantiate(playerExplosion, transform.position, Quaternion.identity);
        _audioManager.PlayPlayerExplosion();
        
        tint.SetActive(true);
        gameOverScreen.SetActive(true);
        
        var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        var text = "Game Over!\n Your total score is: " + gameManager.totalScore;
        gameOverScreen.GetComponentInChildren<TMP_Text>().text = text;
        
        GameObject.Find("Soundtrack").GetComponent<AudioSource>().mute = true;
        
        gameObject.SetActive(false);
    }
}
