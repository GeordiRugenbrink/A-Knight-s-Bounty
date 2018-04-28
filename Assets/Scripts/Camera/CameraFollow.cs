using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform _target;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float _smoothSpeed = 0.125f;
    private const float Z_OFFSET = -10;

    private Vector3 _destination;
    private Vector3 _smoothedPosition;

    private void Awake() {
        _target = FindObjectOfType<Player>().transform;
    }

    private void LateUpdate() {
        _destination = _target.position + _offset;
        _smoothedPosition = Vector3.Lerp(transform.position, _destination, Time.deltaTime * _smoothSpeed);
        _smoothedPosition.z = Z_OFFSET;
        transform.position = _smoothedPosition;
    }
}