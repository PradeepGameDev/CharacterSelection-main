using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public List<Transform> targetPoints;
    public GameManager gameManager;

    public void ChangePosition()
    {
        int index = Random.Range(0, targetPoints.Count);
        transform.position = new Vector3(
            targetPoints[index].position.x,
            transform.position.y,
            targetPoints[index].position.z);

        gameManager.IncreaseScore(1);
    }
}