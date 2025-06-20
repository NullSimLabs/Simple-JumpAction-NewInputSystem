// # ✅ `JumpController.cs` (Full Clean Example Script)

using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleJumpActionNewInputSystem : MonoBehaviour
{
    public PlayerInputActions playerInput;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float jumpHeight = 9f;
    [SerializeField] private float gravityMultiplier = 2f;

    private void Awake()
    {
        playerInput = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnEnable()
    {
        playerInput.Player_OnLand.Jump.performed += OnJumpPerformed;
        playerInput.Player_OnLand.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player_OnLand.Jump.performed -= OnJumpPerformed;
        playerInput.Player_OnLand.Disable();
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            Debug.Log("Jump performed");
        }
    }

    private bool IsGrounded()
    {
        float extraBottomCapsuleHeight = 0.1f;
        float groundRadius = 0.3f;
        RaycastHit raycastHit;

        bool isHit = Physics.SphereCast(
            capsuleCollider.bounds.center,
            groundRadius,
            Vector3.down,
            out raycastHit,
            capsuleCollider.bounds.extents.y + extraBottomCapsuleHeight
        );

        Color rayColor = isHit ? Color.green : Color.red;
        Debug.DrawRay(
            capsuleCollider.bounds.center,
            Vector3.down * (capsuleCollider.bounds.extents.y + extraBottomCapsuleHeight),
            rayColor,
            1f
        );

        return isHit;
    }

    private void Update()
    {
        isGrounded = IsGrounded();
    }

    private void ApplyExtraGravity()
    {
        if (!isGrounded)
        {
            Vector3 extraGravity = Physics.gravity * (gravityMultiplier - 1f);
            rb.AddForce(extraGravity, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate()
    {
        ApplyExtraGravity();
    }
}
