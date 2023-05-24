using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private IAControls playerControls;
    private InputAction press;
    private InputAction position;
    private InputAction move;
    // Start is called before the first frame update
    public Camera mainCam;
    Vector2 mousePosition;
    public GameObject Joystick;
    public GameObject IJoystick;

    bool bOnClick;
    protected float Timer;
    public float DelayAmount = 0.1f;

    [Header("Player")]
    public Rigidbody2D rb;
    Vector2 movement;
    public GameObject player;
    float movementSpeed;


    void Awake()
    {
        //IAControls.Enable();
        playerControls = new IAControls();
    }
    private void OnEnable()
    {
        press = playerControls.Touch.Press;
        position = playerControls.Touch.Position;
        move = playerControls.Player.Move;
        press.Enable();
        move.Enable();
        position.Enable();
        press.performed += Click;
    }
    private void OnDisable()
    {
        press.Disable();
        move.Disable();
        position.Disable();
    }
    void Start()
    {
        //GameObject Joystick = GameObject.Find("Joystick");
        playerControls.Touch.Press.started += ctx => StartTouch(ctx);
        playerControls.Touch.Press.canceled += ctx => EndTouch(ctx);
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();
        movementSpeed = player.GetComponent<BasicVariables>().movementSpeed;
        //playerInput = GetComponent<PlayerInput>();
        bOnClick = false;
        //rend = Joystick.GetComponent<CanvasRenderer>();
    }
    void FixedUpdate()
    {
        Vector2 movement = playerControls.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirectionJ = new Vector3(movement.x * movementSpeed, movement.y * movementSpeed, 0).normalized;
        rb.velocity = new Vector2(moveDirectionJ.x * movementSpeed, moveDirectionJ.y * movementSpeed);

        float temp = playerControls.Touch.Press.ReadValue<float>();
        
        if (temp == 1 )
        {
            if (bOnClick == false)
            {
               //IJoystick.GetComponent<RectTransform>().anchoredPosition = Camera.main.ScreenToWorldPoint(playerControls.Touch.Position.ReadValue<Vector2>());
                Joystick.transform.position = Camera.main.ScreenToWorldPoint(playerControls.Touch.Position.ReadValue<Vector2>());
                Joystick.transform.position = new Vector3(Joystick.transform.position.x, Joystick.transform.position.y, 1f);
                //Joystick.GetComponent<Transform>().position = playerControls.Touch.Position.ReadValue<Vector2>();
                bOnClick = true;
                //Debug.Log("bOnClick false");
            }
            
            //Debug.Log("pressed" + Time.deltaTime);
            //Debug.Log(playerControls.Touch.Position.ReadValue<Vector2>());
            //Debug.Log(Camera.main.ScreenToWorldPoint(playerControls.Touch.Position.ReadValue<Vector2>()));
            //Joystick.GetComponent<Transform>().position = new Vector3(0, 0, 0);
            

        }
        else
        {
            Timer += Time.deltaTime;
            if (Timer >= DelayAmount) { 
                bOnClick = false;
                Joystick.transform.position = new Vector3(100f, 100f, -10.0f);
                //Joystick.SetActive(false);
                //Joystick.SetActive(false); BREAKS the script
                // rend.enabled = false;
                Timer = 0f;
            }
        }
        //Debug.Log(Input.mousePosition);
        //var projectedMousePosition = mainCam.ScreenToWorldPoint(mousePosition);
        //Debug.Log(projectedMousePosition);
    }
    public void Update()
    {
        //Debug.Log(playerControls.Touch.Position.ReadValue<Vector2>());
    }
    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("StartTouch: " + context.ReadValue<float>());
    }
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("EndTouch: " + context.ReadValue<float>());
        
    }

    private void Click(InputAction.CallbackContext context)
    {
        //Debug.Log("InputController: clicked1");
    }
    void OnPosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        
    }
}
