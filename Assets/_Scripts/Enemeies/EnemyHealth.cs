using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int deathScore;
    [SerializeField]
    private int _Health;
    [SerializeField]
    private int _MaxHealth = 1;
    public int CurrentHealth { get => _Health; private set => _Health = value; }
    public int MaxHealth { get => _MaxHealth; private set => _MaxHealth = value; }

    public event IDamagable.TakeDamageEvent OnTakeDamage;
    public event IDamagable.DeathEvent OnDeath;

    private void OnEnable()
    {
        _Health = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        int damageTaken = Mathf.Clamp(Damage, 0, CurrentHealth);

        CurrentHealth -= damageTaken;

        if (damageTaken != 0)
        {
            AudioManager.GetInstance().Play("EnemyHit");

            OnTakeDamage?.Invoke(damageTaken);
        }

        if (CurrentHealth == 0 && damageTaken != 0)
        {
            OnDeath?.Invoke(this.gameObject);
            ScoreManager.GetInstance().IncreaseScore(deathScore);
        }
    }

}
