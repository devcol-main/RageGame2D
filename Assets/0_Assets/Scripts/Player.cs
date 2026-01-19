using UnityEngine;

public class Player : MonoBehaviour
{
    //
    public static Player Instance { get; private set; }

    //
    InputReader IR => InputReader.Instance;

    [Header("References")]    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;

    [Header("Player Stats")]
    [SerializeField] private float maxFuel;
    [SerializeField] private float currentFuel;


    [Header("Movements")]
    [SerializeField] private float force;
    //[SerializeField] private float extraForce;
    [SerializeField] private float turnSpeed;

    public bool toggleDown = false;

    [SerializeField] private Vector2 currentVelocity;
    [SerializeField] private float currentAngularVelocity;


    void Awake()
    {
        Instance = this;
       // InputReader.Instance.IsUpPressed
    }


    public void OnDown(bool performed)
    {
        Debug.Log("From player Down Pressed : " + performed);
        
    }

    void FixedUpdate()
    {


        if(IR.IsUpPressed())
       {
            // it affects on global point of rb 
            //rb.AddForce(new Vector2(0,force));

            // Local
            //rb.linearVelocity = Vector3.zero;
            //rb.angularVelocity = 0f;

            rb.AddForce( (-1*transform.up ) * (force) * Time.fixedDeltaTime);   
        
       }

       if(IR.IsDownPressed())
       {
            // it affects on global point of rb 
            //rb.AddForce(new Vector2(0,1));

            // Local
            //rb.AddForce( (transform.up ) * (force + extraForce) * Time.fixedDeltaTime);   
            rb.AddForce( (transform.up ) * (force) * Time.fixedDeltaTime);   

            // 토글로 해보자            
            if(!toggleDown)
            {
                Debug.Log("IsDownPressed in Player");   
                toggleDown = true;              
                //rb.AddForce( (transform.up ) * (force + extraForce) * Time.fixedDeltaTime);
                             
            }

       }
       else
        {
            toggleDown = false;
        }

       if(IR.IsLeftPressed())
       {
            //rb.AddForce( (transform.up ) * force * Time.fixedDeltaTime);
            //rb.AddTorque(turnSpeed * Time.fixedDeltaTime);
            rb.AddTorque(-turnSpeed * Time.fixedDeltaTime);
       }

       if(IR.IsRightPressed())
       {
            //rb.AddForce( (transform.up ) * force * Time.fixedDeltaTime);
            //rb.AddTorque(-turnSpeed * Time.fixedDeltaTime);
            rb.AddTorque(turnSpeed * Time.fixedDeltaTime);
       }
   

    }

    void LateUpdate()
    {
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -100f,100f);

        currentVelocity = rb.linearVelocity;
        currentAngularVelocity = rb.angularVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
