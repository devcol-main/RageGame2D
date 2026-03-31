using UnityEngine;

public class SpaceStationFuelEnter : MonoBehaviour
{
    [SerializeField] private SpaceStation spaceStation;
    //[SerializeField] private float enterSpeedLimit = 0.1f; // 0.07 ~ 0.15


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("SpaceStationFuelEnter OriggerEnter2D");
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (CheckDocking(rb))
            {
                //ForceZeroVelocity
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = 0f;

                //
                spaceStation.DockingSuccess();

            }
            else
            {
                spaceStation.DockingFailure();
            }


            // Check Player's correct pos and velocity

            //rd.linearVelocity = Vector3.zero;
            //rd.AddForce(Vector3.up * force);
            //rd.AddForce(transform.up * force);

        }
    }

    private bool CheckDocking(Rigidbody2D rd)
    {
        bool result;
        float enterSpeed = Mathf.Abs(rd.linearVelocity.y);
        Debug.Log("Speed: " + enterSpeed);


        if (enterSpeed > spaceStation.GetEntranceSpeedLimit())
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
