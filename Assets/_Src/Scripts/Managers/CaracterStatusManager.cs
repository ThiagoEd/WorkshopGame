using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CaracterStatusMagenager : MonoBehaviour, IDamageable
{
    public Status status;

    public event Action OnTakeDamage;

    private void Start()
    {
        status.Init();
    }
    public void TakeDamage(int amount)
    {
        status.Health -= amount;
        OnTakeDamage?.Invoke();

        if(status.Health <= 0)
        {
            Die();
        }
    }

    private void Die ()
    {
        Destroy(this.gameObject);
    }

    private void Update ( )
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(UnityEngine.Random.Range(1,50));
        }
    }
}
