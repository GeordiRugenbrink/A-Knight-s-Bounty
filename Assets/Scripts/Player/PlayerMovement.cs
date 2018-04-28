using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    [SerializeField]
    private float movementSpeed = 5f;

    void Update() {
        Movement();
    }

    public void Movement() {
        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), movementSpeed);
    }
}
