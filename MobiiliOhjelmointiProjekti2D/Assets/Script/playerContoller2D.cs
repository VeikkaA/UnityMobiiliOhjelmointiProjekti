using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller2D : MonoBehaviour
{
    public joystickScript joystickScript;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    public float minX = -1.95f;
    public float maxX = 1.95f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        joystickMovement();
        PositionLimit();
    }
    void joystickMovement()
    {
        float moveX = joystickScript.Horizontal();
        Vector2 movement = new Vector2(moveX * moveSpeed, rb.velocity.y);

        rb.velocity = movement;
    }
    void PositionLimit()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }
}
