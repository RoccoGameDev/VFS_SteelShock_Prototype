using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAiming : MonoBehaviour
{
    [Header("Aim Data")]
    [SerializeField] private float _controllerDeadzone = 0.1f;
    [SerializeField] private float _gamepadRotateSmoothing = 1000f;
    
    [SerializeField] private bool _isGamepad;

    Vector2 aim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleAim();
    }

    public void Aim(InputAction.CallbackContext ctx)
    {
        aim = ctx.ReadValue<Vector2>();
    }

    void HandleAim()
    {
        if (_isGamepad == true)
        {
            if (Mathf.Abs(aim.x) > _controllerDeadzone || Mathf.Abs(aim.y) > _controllerDeadzone)
            {
                Vector3 playerDir = Vector3.right * aim.x + Vector3.forward * aim.y;

                if (playerDir.sqrMagnitude > 0.0f)
                {
                    Quaternion newRotation = Quaternion.LookRotation(playerDir, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, _gamepadRotateSmoothing * Time.deltaTime);
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 mouse = hit.point;

                transform.LookAt(new Vector3(mouse.x, transform.position.y, mouse.z));
            }
        }
    }

    public void OnDeviceChange(PlayerInput pi)
    {
        _isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }
}
