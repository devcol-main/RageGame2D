using UnityEngine;

public class SpaceStationFuelEnter : MonoBehaviour
{
    [SerializeField] private SpaceStation spaceStation;
    [SerializeField] private float enterSpeedLimit = 0.1f; // 0.07 ~ 0.15


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("SpaceStationFuelEnter OriggerEnter2D");
            Rigidbody2D rd = collision.GetComponent<Rigidbody2D>();

            if(CheckDocking(rd, player))
            {
                spaceStation.DockingSuccess();

            }



            // Check Player's correct pos and velocity
            
            //rd.linearVelocity = Vector3.zero;
            //rd.AddForce(Vector3.up * force);
            //rd.AddForce(transform.up * force);
            
        }
    }

    private bool CheckDocking(Rigidbody2D rd, Player player)
    {
        bool result;
        float enterSpeed = Mathf.Abs(rd.linearVelocity.y);
        Debug.Log("Speed: " + enterSpeed);

        if (enterSpeed > enterSpeedLimit)
        {
            return false;
        }
        else
        {
            result = true;
        }

        //enterSpeedLimit

        return result;
    }
}
