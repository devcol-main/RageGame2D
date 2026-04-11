using UnityEngine;
using PrimeTween;
using System;

public class Tweening : MonoBehaviour
{
    [Header("Rotating Z")]
    [SerializeField] private bool isRotatingZ = true;
    [SerializeField] private bool isRotatingZRandom = true;
    [SerializeField] private bool isRotatingZPositive = true;
    
    [Space(10f)]
    [SerializeField] private bool isRotatingZRandomSpeed = true;
    [SerializeField] private float rotateDuration = 0;

    [Header("Size")]
    [SerializeField] private bool isRandomSize = true;

    [SerializeField] private float randomSizeRangeMin;
    [SerializeField] private float randomSizeRangeMax;
    [SerializeField] private float size;

    //
    private Tween rotatingTween;

    void Start()
    {
        TweeningRotation();
        // Roating Z
        if (isRotatingZ)
        {
            if (isRotatingZRandom)
            {
                if (isRotatingZRandomSpeed)
                {
                    //rotationSpeed = Random.Range()
                }
                //rotateDuration = Random.Range()
            }
            else
            {
                
            }
        }

        if (isRandomSize)
        {
            
        }

        // Tween.Rotation(transform, endValue: Quaternion.Euler(0, 90, 0), duration: 1);

    }

    private void TweeningRotation()
    {
        // Rotate 'transform' around the z-axis by 360 degrees in 1 second 
        // z-axis [positive] == spin left | [negative] == spin right
        // cycles: -1 == infinite
        rotatingTween = Tween.EulerAngles(this.transform, 
            startValue: Vector3.zero, endValue: new Vector3(0,0,-360), duration: rotateDuration, 
            ease: Ease.Linear, cycles: -1);
    }



}
