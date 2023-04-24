using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseActions : AiAction

{



    public override void TakeAction()
    {
        var directions = enemyBrain.Target.transform.position - transform.position;
        aiMovementData.Direction = directions.normalized;
        aiMovementData.PointOfInterest = enemyBrain.Target.transform.position;
        enemyBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
    }
}
