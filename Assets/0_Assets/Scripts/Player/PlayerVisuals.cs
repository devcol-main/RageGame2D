using System;
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

    

    void Awake()
    {
        SetAllThrusterPS(false);
        
    }
    void Start()
    {
        playerController = GetComponent<PlayerController>();   

        playerController.OnUpForce += OnUpForce;
        playerController.OnDownForce += OnDownForce;
        playerController.OnLeftForce += OnLeftForce;
        playerController.OnRightForce += OnRightForce;
        
        //
        playerController.OnBeforeForce += OnBeforeForce;

        playerController.OnBeforeActionForce += OnBeforeActionForce;
    }

    void OnDisable()
    {
       
    }
    public void OnBeforeActionForce()
    {
        
        SetAllThrusterPS(false);
    }

    private void OnBeforeForce(object sender, EventArgs e)
    {
       
        SetAllThrusterPS(false);
    }

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
}
