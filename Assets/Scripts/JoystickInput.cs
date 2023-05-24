using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    public float movementSpeed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody2D rb;
    public GameObject player;
    Vector2 movement;
    private RectTransform FJtransform;
    public Vector3 moveDirection;

    public void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        //floatingJoystick = GameObject.Find("FloatingJoystick");
        movementSpeed = player.GetComponent<BasicVariables>().movementSpeed;
        FJtransform = floatingJoystick.GetComponent<RectTransform>();

        //Camera coordinates
        //Camera camera = Camera.main;

        //float halfHeight = camera.orthographicSize * 2;
        //float halfWidth = camera.aspect * halfHeight;

        ////Canvas coordinates
        //Canvas canvas = FindObjectOfType<Canvas>();
        //float h = canvas.GetComponent<RectTransform>().rect.height;
        //float w = canvas.GetComponent<RectTransform>().rect.width;

        //FJtransform.sizeDelta = new Vector2(w, h / 2);
        //camera.transform.position = canvas.transform.position;
    }
    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        movement.x = floatingJoystick.Horizontal;
        movement.y = floatingJoystick.Vertical;
        moveDirection = new Vector3(movement.x * movementSpeed, movement.y * movementSpeed, 0).normalized;
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}
