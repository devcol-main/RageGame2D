using UnityEngine;

public class TestSO : MonoBehaviour
{
    [SerializeField] public SFX_PlayerSO playerTest; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTest.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
