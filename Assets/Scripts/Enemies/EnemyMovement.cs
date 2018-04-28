using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float walkingDistance = 10f;

    private void Update() {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer() {
        if (CalculateDistance() <= walkingDistance) {
            var target = Utility.player.transform.position;
            var direction = (Vector2)(target - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    public float CalculateDistance() {
        var playerPos = Utility.player.transform.position;
        var distance = (playerPos - transform.position).sqrMagnitude;
        return distance;
    }
}
