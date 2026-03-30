using UnityEngine;

public class DirectionBounce : CollideableObject
{
    //[SerializeField] private Collider2D col;

    [Tooltip("Default value 200")]
    [SerializeField] private float force;

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("COLLL");
    //     collision.rigidbody.linearVelocity = Vector3.zero;
    //     collision.rigidbody.AddForce(Vector3.up * force);
        
        
    //     // rb.linearVelocity = Vector3.zero;
    // }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("Direction Bounce OriggerEnter2D");
            Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();

            if(rd.linearVelocity.y < 0)
            {
                rd.linearVelocity = Vector3.zero;
            }
            
            //rd.linearVelocity = Vector3.zero;
            //rd.AddForce(Vector3.up * force);
            rd.AddForce(transform.up * force);
            
        }
        
    }

   
}
