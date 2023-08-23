using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject pointPrefab;
    public Transform lifebar;
    public int maxHealth = 3;
    private int currentHealth;

    [SerializeField] GameEvent OnDied;
    [SerializeField] CanvasType gameOverScreen;

    private void Start()
    {
        currentHealth = maxHealth;
        SetLifebar();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update lifebar representation
        UpdateLifebar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void SetLifebar()
    {
        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(pointPrefab, lifebar);
        }
    }

    void UpdateLifebar()
    {
        // Destroy the last child (point object) of the lifebar
        if (lifebar.childCount > 0)
        {
            Destroy(lifebar.GetChild(lifebar.childCount - 1).gameObject);
        }
    }

    private void Die()
    {
        OnDied.Invoke();

        CanvasManager.GetInstance().SwitchCanvas(gameOverScreen);

        Time.timeScale = 0f;
    }
}
