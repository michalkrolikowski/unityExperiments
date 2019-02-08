using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour {
    [SerializeField] float speed;

    Transform cachedTransfom;

    void Awake() => cachedTransfom = GetComponent<Transform>();

    void Update()
    {
        var currentMovement =
            MoveIfDown(Vector3.left, KeyCode.A) +
            MoveIfDown(Vector3.right, KeyCode.D) +
            MoveIfDown(Vector3.forward, KeyCode.S) +
            MoveIfDown(Vector3.back, KeyCode.W) +
            MoveIfDown(Vector3.up, KeyCode.Q) +
            MoveIfDown(Vector3.down, KeyCode.E);

        cachedTransfom.Translate(currentMovement * Time.deltaTime * speed);
    }

    Vector3 MoveIfDown(Vector3 direction, KeyCode input) {
        return Input.GetKey(input) ? direction : Vector3.zero;
    }
}
