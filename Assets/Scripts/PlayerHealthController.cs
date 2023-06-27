using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //[HideInInspector]
    public int currentHealth;
    public int maxHealth;
    public int currentStability;
    public int maxStability;

    public float invincibilityLength;
    private float invincCounter;
    public float flashLength;
    private float flashCounter;
    public SpriteRenderer[] playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.UpdateHealth(currentHealth, maxHealth);

        currentStability = 0;

        UIController.instance.UpdateStability(currentStability, maxStability);

    }

    void Update()
    {
        if (invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprite)
                {
                    sr.enabled = !sr.enabled;
                }
                flashCounter = flashLength;
            }

            if (invincCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprite)
                {
                    sr.enabled = true;
                }
                flashCounter = 0f;
            }
        }


    }

    public void DamagePlayer(int damageAmount)
    {
        if (invincCounter <= 0)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);

                RespawnController.instance.Respawn();
            }
            else
            {
                invincCounter = invincibilityLength;
            }

            UIController.instance.UpdateHealth(currentHealth, maxHealth);
        }

    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealth(currentHealth, maxHealth);

    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealth(currentHealth, maxHealth);

    }

    public void HandleStability(int stabilityAmount)
    {
        currentStability += stabilityAmount;

        if (currentStability > maxStability)
        {
            currentStability = maxStability;
        }

        UIController.instance.UpdateStability(currentStability, maxStability);
    }

    public static int returnStability(int currentStability)
    {
        return currentStability;
    }

}
