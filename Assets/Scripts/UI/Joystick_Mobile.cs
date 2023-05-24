using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]



public class Joystick_Mobile : MonoBehaviour
{
    //public PlayerInput IAControls;
    //public InputAction fire;
    //private PlayerInput playerInput;

    //private void Awake()
    //{
    //    playerInput = GetComponent<PlayerInput>();
    //    //playerInput = new PlayerInput();
    //}

    //private void OnEnable()
    //{
    //    IAControls.Enable();
    //    fire = IAControls.Player.Move;
    //}
    //private void OnDisable()
    //{
       
    //    inputAction.Disable();
    //}
    //private void Start()
    //{
    //    Vector2 input = playerInput.actions["PrimaryTouch"].ReadValue<Vector2>();
    //    Debug.Log(input);
    //    //playerInput.Touch.Press.started += ctx => StartTouch(ctx);
    //    //playerInput.Touch.Press.canceled += ctx => EndTouch(ctx);
    //}
    //private void FixedUpdate()
    //{
    //    Vector2 input = playerInput.actions["PrimaryTouch"].ReadValue<Vector2>();
    //    if (input.x != 0) { 
    //        Debug.Log(input);
    //    }
    //    //playerInput.Touch.Press.started += ctx => StartTouch(ctx);
    //    //playerInput.Touch.Press.canceled += ctx => EndTouch(ctx);
    //}
    //private void StartTouch()
    //{
    //    Debug.Log("Touch started ");
    //}
    //private void EndTouch()
    //{
    //    Debug.Log("Touch ended ");
    //}
    //private void Start()
    //{

    //    gameObject.SetActive(true);
    //    playerInput = GetComponent<PlayerInput>();

    //}
    //private void FixedUpdate()
    //{
    //    Debug.Log(playerInput.actions["Press"].ReadValue<Vector2>());
    //    //Debug.Log(touch2.position);   
    //    //playerInputActions.Touch.Press.performed += Touch;
    //    if (Input.touchCount > 0)
    //    {
    //        Debug.Log(Input.touchCount);
    //    }

    //    if (Input.touchCount > 0 & gameObject.activeSelf == false)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        this.transform.position = touch.position;
    //        gameObject.SetActive(true);
    //        //_rigidbody.velocity = new Vector3(_joystick.Horizontal * movementSpeed, _joystick.Horizontal * movementSpeed, 1);
    //    } else
    //    {
    //        //gameObject.SetActive(false);
    //    }

    //    //void Touch(InputAction.CallbackContext context)
    //    //{
    //    //    print("Touch");
    //    //}
    //}
}
