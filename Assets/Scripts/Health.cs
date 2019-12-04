using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;
    [SerializeField] float maxHealthPoints = 100f;
    [SerializeField] AudioClip playerHitSFX;
    bool isDead = false;

    HealthBar healthBar;

    private void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetHealthBar(healthPoints, maxHealthPoints);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        healthBar.SetHealthBar(healthPoints, maxHealthPoints);
        AudioSource.PlayClipAtPoint(playerHitSFX, Camera.main.transform.position, 1f);
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        print("**** Player Dead ****");
    }
}
