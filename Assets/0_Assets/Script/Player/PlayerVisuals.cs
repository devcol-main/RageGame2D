using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [Header("Particle Systems")]
    [SerializeField] private ParticleSystem upThrusterPS;
    [SerializeField] private ParticleSystem downThrusterPS;
    [SerializeField] private ParticleSystem leftThrusterPS;
    [SerializeField] private ParticleSystem rightThrusterPS;

    //[SerializeField] 
    private float allThrusterOnDuration = 0.2f;

    private bool isThrusterPSOn = false;
    
    [Space(5f)]
    [SerializeField] private ParticleSystem explotionPS;

    

    void Awake()
    {
        SetAllThrusterPS(isThrusterPSOn);
        //explotionPS.transform.rotation = new Vector3
        
    }
    void Start()
    {
        playerController = GetComponent<PlayerController>();   

        playerController.OnUpForce += OnUpForce;
        playerController.OnDownForce += OnDownForce;
        playerController.OnLeftForce += OnLeftForce;
        playerController.OnRightForce += OnRightForce;

        playerController.OnAllForce += OnAllForce;
        
        //
        //playerController.OnBeforeForce += OnBeforeForce;

        playerController.OnBeforeActionForce += OnBeforeActionForce;

        //
        Player.Instance.OnCrash += OnCollision;
    }

    

    void OnDisable()
    {
       
    }
    public void OnBeforeActionForce()
    {
        SetAllThrusterPS(isThrusterPSOn);
    }

    // private void OnBeforeForce(object sender, EventArgs e)
    // {
       
    //     SetAllThrusterPS(false);
    // }

    private void OnRightForce(object sender, EventArgs e)
    {
        SetThrusterPS(rightThrusterPS, true);
    }

    private void OnLeftForce(object sender, EventArgs e)
    {
        SetThrusterPS(leftThrusterPS, true);
    }

    private void OnDownForce(object sender, EventArgs e)
    {
        SetThrusterPS(downThrusterPS, true);
    }

    private void OnUpForce(object sender, EventArgs e)
    {
        //Debug.Log("OnUpForce SetThrusterPS");
        SetThrusterPS(upThrusterPS, true);
    }


    private void OnAllForce(object sender, EventArgs e)
    {
        
        isThrusterPSOn = true;

        SetAllThrusterPS(isThrusterPSOn);
        // after duration turn off;

        Invoke("OffThrusterPS", allThrusterOnDuration);
    }

    private void OffThrusterPS()
    {
        isThrusterPSOn = false;
    }

    

    private void SetAllThrusterPS(bool enabled)
    {
        SetThrusterPS(upThrusterPS, enabled);
        SetThrusterPS(downThrusterPS, enabled);
        SetThrusterPS(leftThrusterPS, enabled);
        SetThrusterPS(rightThrusterPS, enabled);
    }

    private void SetThrusterPS(ParticleSystem ps, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = ps.emission;
        emissionModule.enabled = enabled; 
    }
    //
    private void OnCollision()
    {
        // explotionPS rotation seted as -90,0,0, but when Instantiate it resets so set rotation in scirpt again
        // you can prevent by set ps in child of object. but i rather do it this way
        //Instantiate(explotionPS, transform.position, Quaternion.identity);
        Instantiate(explotionPS, transform.position, Quaternion.Euler(-90, 0, 0));
    }
}
