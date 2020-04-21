using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public static int totalScore = 0;
    Text score;
    public Text final;
    public GameObject gameUI;
    public GameObject deathPanel;
    public Slider healthBar;
    public Gradient healthGradient;
    public Image fill;
    public static int maxHealth = 100;
    public static int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
        deathPanel.SetActive(false);
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(currentHealth);
        score.text = "Score: " + totalScore;
        if(PlayerController.alive == false) 
        {
            final.text = "Final Score: " + totalScore;
            EnemySpawnerController.spawnAllowed = false;
            deathPanel.SetActive(true);
            totalScore = 0;
            gameUI.SetActive(false);
        }
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;

        fill.color = healthGradient.Evaluate(healthBar.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = healthGradient.Evaluate(1f);
    }
}
