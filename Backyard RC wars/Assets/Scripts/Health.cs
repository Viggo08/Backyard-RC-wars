using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int tankHealth;
    public int currentHealth;
    int playerNummber;
    private void Awake()
    {
        currentHealth = tankHealth;
        if(GameObject.FindGameObjectWithTag("Player")  == null)
        {
            playerNummber = 1;
        }
        else
        {
            playerNummber = 2;
        }
    }

    private void Update()
    {
       // Death();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void Death()
    {
        if(currentHealth <= 0 && playerNummber == 1)
        {


           // SceneManager.LoadScene("WinScene1");
        }
        if (currentHealth <= 0 && playerNummber == 2)
        {
            // SceneManager.LoadScene("WinScene2");
        }
    }
}
