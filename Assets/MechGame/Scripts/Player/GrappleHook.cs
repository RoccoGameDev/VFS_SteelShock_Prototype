using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    [Header("Grapple Hook Data")]
    [SerializeField] private float _maxGrappleDistance = 100f;

    [SerializeField] public LayerMask whatIsGrappleable;
    [SerializeField] public Transform grapplePOS, playerPOS;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
