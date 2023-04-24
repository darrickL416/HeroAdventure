using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiState : MonoBehaviour
{

    private EnemyAiBrain enemyBrain = null;


    [field: SerializeField]
    private List<AiAction> actions = null;

    [field: SerializeField]
    private List<AiTransition> transitions = null;

    private void Awake()
    {
        enemyBrain = transform.root.GetComponent<EnemyAiBrain>();
    }

    public void UpdateState()
    {
        foreach (var action in actions)
        {
            action.TakeAction();
        }

        foreach (var transition in transitions)
        {

            //player in range -> true -> Back to Idle
            // player visable -> True -> Chase


            bool result = false;

            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeADecidion();
                if (result == false)
                    break;
            }

            if (result)
            {
                if(transition.PositiveResult != null)
                {
                    enemyBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if(transition.NegativeResult != null)
                {
                    enemyBrain.ChangeToState(transition.NegativeResult);
                    return;
                }
            }
        }

    }


}
