# Unity Jump System with Grounded Check

A simple Unity C# example that adds a jump system to your player controller — using Rigidbody physics, SphereCast-based ground check, and Unity's new Input System.

---

## 🎮 Features

- Jump using AddForce with customizable jump height
- SphereCast-based grounded check (handles uneven terrain)
- Optional extra gravity when falling (makes jump feel snappier)
- Debug visualization (green = grounded, red = not grounded)
- Works with Unity's new Input System

---

## 🛠 Requirements

- Rigidbody on the player GameObject  
- CapsuleCollider on the player GameObject  
- Unity's new Input System (`PlayerInputActions` generated)

---

## 📋 How To Add This To Your PlayerController Script

---

### 1️⃣ Required Components on Player GameObject

- Rigidbody (Use Gravity = true)
- CapsuleCollider

---

### 2️⃣ Variables to add:

```csharp
public PlayerInputActions playerInput;
private Rigidbody rb;
private CapsuleCollider capsuleCollider;
[SerializeField] private bool isGrounded = true;
[SerializeField] private float jumpHeight = 9f;
[SerializeField] private float gravityMultiplier = 2f;

3️⃣ Awake():
csharp
Copy
Edit
private void Awake()
{
    playerInput = new PlayerInputActions();
    rb = GetComponent<Rigidbody>();
    capsuleCollider = GetComponent<CapsuleCollider>();
}
4️⃣ OnEnable():
csharp
Copy
Edit
playerInput.Player_OnLand.Jump.performed += OnJumpPerformed;
playerInput.Player_OnLand.Enable();
5️⃣ OnDisable():
csharp
Copy
Edit
playerInput.Player_OnLand.Jump.performed -= OnJumpPerformed;
playerInput.Player_OnLand.Disable();
6️⃣ OnJumpPerformed():
csharp
Copy
Edit
private void OnJumpPerformed(InputAction.CallbackContext ctx)
{
    if (isGrounded)
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        Debug.Log("Jump performed");
    }
}
7️⃣ IsGrounded():
csharp
Copy
Edit
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
8️⃣ Update():
csharp
Copy
Edit
private void Update()
{
    isGrounded = IsGrounded();
}
9️⃣ Optional: Extra gravity
csharp
Copy
Edit
private void ApplyExtraGravity()
{
    if (!isGrounded)
    {
        Vector3 extraGravity = Physics.gravity * (gravityMultiplier - 1f);
        rb.AddForce(extraGravity, ForceMode.Acceleration);
    }
}
🔟 Optional: FixedUpdate()
csharp
Copy
Edit
private void FixedUpdate()
{
    ApplyExtraGravity();
}
