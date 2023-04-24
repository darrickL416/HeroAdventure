using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, Ihittable, IAgent
{
    [field: SerializeField]
    public EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }


    private void Start()
    {
        Health = EnemyData.MaxHealth;
    }



    public void GetHit(int damage, GameObject damagDealer)
    {
        Health--;
        OnGetHit?.Invoke();
        if (Health <= 0)
        {
            OnDie?.Invoke();
            StartCoroutine(WaitToDie());

        }
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(.53f);
        Destroy(gameObject);
    }
}
