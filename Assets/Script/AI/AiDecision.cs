using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AiDecision : MonoBehaviour
{

    protected AiActionData aiActionData;

    protected AiMovementData aiMovementData;

    protected EnemyAiBrain enemyBrain;

    private void Awake()
    {
        aiActionData = transform.root.GetComponentInChildren<AiActionData>();
        aiMovementData = transform.root.GetComponentInChildren<AiMovementData>();

        enemyBrain = transform.root.GetComponent<EnemyAiBrain>();
    }

    public abstract bool MakeADecidion();
}
