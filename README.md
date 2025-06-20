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
