using System;
using UnityEngine;

public enum Direction
{
    UP, DOWN, LEFT, RIGHT,
}

public class PlayerController : MonoBehaviour
{
    public event EventHandler OnUpForce;
    public event EventHandler OnDownForce;
    public event EventHandler OnLeftForce;
    public event EventHandler OnRightForce;
    //public event EventHandler OnBeforeForce;
    public Action OnBeforeActionForce;
    
    InputReader IR => InputReader.Instance;

    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D rb;
    
    
    [Header("Movements")]
    [SerializeField] private float force = 150f;
    //[SerializeField] private float extraForce;
    [SerializeField] private float turnSpeed = 75f;

    //public bool toggleDown = false;

    [Header("For DEBUG")]
    [SerializeField] private Vector2 currentVelocity;
    [SerializeField] private float currentAngularVelocity;

    [SerializeField] private float gamepadDeadzone = 0.4f;

    // =====
    public Vector2 moveInput;
    public float GetPlayerCurrentSpeed()
    {
        return (Mathf.Abs(rb.linearVelocity.y) * 10 );
    }   
    // =====
    

    void Awake()
    {
        // References
        player = GetComponent<Player>();  
        rb = GetComponent<Rigidbody2D>();  
           
    }

    void Start()
    {
        GameManager.Instance.OnStateChanged += OnGameStateChanged;
        
    }

    // =====

    void OnEnable()
    {

        IR.Jump += OnJump;

        //IR.Move += OnMove;

        IR.Move += direction => moveInput = direction;

        
    }

    

    void OnDisable()
    {
        
    }

    void OnJump(bool performed)
    {
        if (performed)
        {
            Debug.Log("OnJump from : " + this.gameObject.name  + "| performed: " + performed); 

            ForceZeroVelocity();
        }
        
    }
    //
    public void ForceZeroVelocity()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = 0f;
    }

    // =====



    private void OnGameStateChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        //Debug.Log($"Player OnGameStateChanged : {e} | {e.state}" );

        if (e.state == State.WatintingToStart)
        {
            
        }

        if (e.state == State.GameStart)
        {
            
        }
    }

    void FixedUpdate()
    {
        //OnBeforeForce?.Invoke(this, EventArgs.Empty);
        OnBeforeActionForce?.Invoke();        
        
        Movements();       

    }

    private void Movements()
    {
        
        if (IR.IsUpPressed() || IR.GetMovementInputVector2().y > gamepadDeadzone )
        {
            ForceDirection(Direction.DOWN);
        }

        if (IR.IsDownPressed() || IR.GetMovementInputVector2().y < -gamepadDeadzone )
        {
            ForceDirection(Direction.UP);

        }
        // else
        // {
        //     toggleDown = false;
        // }

        if (IR.IsLeftPressed() || IR.GetMovementInputVector2().x < -gamepadDeadzone )
        {
            ForceDirection(Direction.RIGHT);
        }

        if (IR.IsRightPressed() || IR.GetMovementInputVector2().x > gamepadDeadzone )
        {
            ForceDirection(Direction.LEFT);
        }
    }

    private void ForceDirection(Direction direction)
    {
        if(!player.ConsumingFuel())
        {
            return;
        }

        switch (direction)
        {
            case Direction.UP:
                {
                    // it affects on global point of rb 
                    //rb.AddForce(new Vector2(0,1));

                    // Local
                    //rb.AddForce( (transform.up ) * (force + extraForce) * Time.fixedDeltaTime);   
                    rb.AddForce((transform.up) * (force) * Time.fixedDeltaTime);

                    // // 토글로 해보자            
                    // if (!toggleDown)
                    // {
                    //     Debug.Log("IsDownPressed in Player");
                    //     toggleDown = true;
                    //     //rb.AddForce( (transform.up ) * (force + extraForce) * Time.fixedDeltaTime);

                    // }

                    //

                    OnDownForce?.Invoke(this, EventArgs.Empty);

                }
                break;
            case Direction.DOWN:
                {
                    // it affects on global point of rb 
                    //rb.AddForce(new Vector2(0,force));

                    // Local
                    //rb.linearVelocity = Vector3.zero;
                    //rb.angularVelocity = 0f;

                    rb.AddForce((-1 * transform.up) * (force) * Time.fixedDeltaTime);
                    OnUpForce?.Invoke(this, EventArgs.Empty);


                }
                break;
            case Direction.LEFT:
                {

                    //rb.AddForce( (transform.up ) * force * Time.fixedDeltaTime);
                    //rb.AddTorque(-turnSpeed * Time.fixedDeltaTime);
                    rb.AddTorque(turnSpeed * Time.fixedDeltaTime);
                    OnRightForce?.Invoke(this, EventArgs.Empty);


                }
                break;
            case Direction.RIGHT:
                {
                    //rb.AddForce( (transform.up ) * force * Time.fixedDeltaTime);
                    //rb.AddTorque(turnSpeed * Time.fixedDeltaTime);
                    rb.AddTorque(-turnSpeed * Time.fixedDeltaTime);

                    OnLeftForce?.Invoke(this, EventArgs.Empty);
                }
                break;
        };


    }

    void LateUpdate()
    {       
        //rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, 0f, brakingStrength * Time.fixedDeltaTime);

        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -100f, 100f);
        
        //
        currentVelocity = rb.linearVelocity;
        currentAngularVelocity = rb.angularVelocity;
    }

}
