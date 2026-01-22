using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BouncingObject : CollideableObject
{
    [SerializeField] private Collider2D col;

    
}
