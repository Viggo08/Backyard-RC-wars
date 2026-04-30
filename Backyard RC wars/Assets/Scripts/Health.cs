using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int tankHealth;
    public int currentHealth;

    private void Awake()
    {
        currentHealth = tankHealth;
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
        if(currentHealth <= 0)
        {
           // SceneManager.LoadScene("WinScene");
        }
    }
}
