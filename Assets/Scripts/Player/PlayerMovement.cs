using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    private StatManager statManager;

    private void Awake() {
        statManager = GetComponent<StatManager>();
    }

    void Update() {
        Movement();
    }

    public void Movement() {
        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), statManager.MovementSpeed);
    }
}
