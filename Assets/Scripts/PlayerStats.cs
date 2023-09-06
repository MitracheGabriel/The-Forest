using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{

    public static int maxHealth = 100;
    public static int currentHealth;
    public static bool isAlive = true;
    public static bool IsLocked = false;

    public GameObject gameOverScreen;
    public FirstPersonController player;
    public Slider healthSlider;
    public AudioSource hitSound;
    public AudioSource deathSound;

    void Start()
    {
        maxHealth = 100;
        currentHealth = 100;
        healthSlider.maxValue = maxHealth;
        player = GetComponent<FirstPersonController>();
    }
    void Update()
    {
        healthSlider.value = currentHealth;
    }
    IEnumerator GameOver()
    {
        player.enabled = false;
        deathSound.Play();
        GetComponent<Animation>().Play("DeathAnim");
        yield return new WaitForSeconds(1);
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        yield return new WaitForSeconds(5);
        
    }
    public void TakeDamage(int damage)
    {
        if (isAlive) {
            hitSound.Play();
            SetCurrentHealth(currentHealth - damage);

            if (currentHealth <= 0)
            {
                isAlive = false;
                StartCoroutine(GameOver());
            }
        }
    }
    public static void SetCurrentHealth(int value)
    {
        currentHealth = value < 0 ? 0 : value > maxHealth ? maxHealth : value;
    }
}
