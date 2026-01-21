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
    public event EventHandler OnBeforeForce;
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

    private void OnGameStateChanged(object sender, GameManager.OnStateChangedEventArgs e)
    {
        Debug.Log($"Player OnGameStateChanged : {e} | {e.state}" );

        if (e.state == State.WatintingToStart)
        {
            
        }

        if (e.state == State.GameStart)
        {
            
        }
    }

    void FixedUpdate()
    {
        OnBeforeForce?.Invoke(this, EventArgs.Empty);
        OnBeforeActionForce?.Invoke();        
        
        if (0 < player.CurrentFuel || player.IsInfiniteFuel)
        {
            Movements(); 
        }
            

    }

    private void Movements()
    {
        if (IR.IsUpPressed())
        {
            ForceDirection(Direction.DOWN);
        }

        if (IR.IsDownPressed())
        {
            ForceDirection(Direction.UP);

        }
        // else
        // {
        //     toggleDown = false;
        // }

        if (IR.IsLeftPressed())
        {
            ForceDirection(Direction.RIGHT);
        }

        if (IR.IsRightPressed())
        {
            ForceDirection(Direction.LEFT);
        }
    }

    private void ForceDirection(Direction direction)
    {
        player.ConsumingFuel();

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
        

        currentVelocity = rb.linearVelocity;
        currentAngularVelocity = rb.angularVelocity;
    }

}
