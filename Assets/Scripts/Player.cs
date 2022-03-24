using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float    acceleration = 10000.0f;
    [SerializeField] private float    maxSpeed = 400.0f;
    [SerializeField] private float    drag = 0.8f;
    [SerializeField] private Vector2  limit = new Vector2(600.0f, 300.0f);

    private Animator    anim;
    private Vector3     moveVector;
    private Vector3     currentVelocity;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        currentVelocity = currentVelocity * drag;

        currentVelocity = currentVelocity + moveVector * acceleration * Time.fixedDeltaTime;

        currentVelocity = currentVelocity.normalized * Mathf.Min(currentVelocity.magnitude, maxSpeed);

        Vector3 newPos = transform.position + currentVelocity * Time.fixedDeltaTime;
        if (newPos.x > limit.x) newPos.x = limit.x;
        else if (newPos.x < -limit.x) newPos.x = -limit.x;

        if (newPos.y > limit.y) newPos.y = limit.y;
        else if (newPos.y < -limit.y) newPos.y = -limit.y;

        transform.position = newPos;

        if (anim)
        {
            anim.SetFloat("SpeedX", currentVelocity.x);
        }
    }

    private void Update()
    {
        moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    }
}
