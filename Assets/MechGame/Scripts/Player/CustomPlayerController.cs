using CharacterMovement;
using UnityEngine;

public class CustomPlayerController : PlayerController
{
    CharacterMovement3D characterMovement3D;

    protected override void Awake()
    {
        characterMovement3D = GetComponent<CharacterMovement3D>();
        base.Awake();
    }

    protected virtual void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            characterMovement3D.SetLookPosition(hit.point);
        }
    }
    
    protected override void Update()
    {
        if (Movement == null) return;

        // find correct right/forward directions based on main camera rotation
        Vector3 up = Vector3.up;
        Vector3 right = Camera.main.transform.right;
        Vector3 forward = Vector3.Cross(right, up);
        Vector3 moveInput = forward * MoveInput.y + right * MoveInput.x;

        // send player input to character movement
        Movement.SetMoveInput(moveInput);
        if (LookInCameraDirection) Movement.SetLookDirection(Camera.main.transform.forward);
    }
}
