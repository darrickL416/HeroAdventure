using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAiBrain : MonoBehaviour, IAgentInput
{
    [field: SerializeField]
    public GameObject Target { get; set; }

    [field: SerializeField]

    public AiState CurrentState { get; private set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get;  set; }

    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set ; }

    [field: SerializeField]
    public UnityEvent OnFirePressedButton { get ; set; }

    [field: SerializeField]
    public UnityEvent OnFirePressedReleased { get; set; }



    private void Awake()
    {
        Target = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        if(Target == null)
        {
            OnMovementKeyPressed?.Invoke(Vector2.zero);
        }
        CurrentState.UpdateState();
    }



    public void Attack()
    {
        OnFirePressedButton?.Invoke();
    }

    public void Move(Vector2 movementDirection, Vector2 targetPosition )
    {
        OnMovementKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(targetPosition);
    }




    internal void ChangeToState(AiState state)
    {
        CurrentState = state;

    }
}
