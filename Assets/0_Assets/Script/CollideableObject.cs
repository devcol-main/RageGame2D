using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public  class CollideableObject : MonoBehaviour
{
    [SerializeField] private Collider2D col;
}
