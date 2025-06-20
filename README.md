![image](https://github.com/user-attachments/assets/44b374fd-fd95-4899-b95f-51ffef55b397)# Unity Jump System with Grounded Check

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
- Create a jump script that is attached to your player and copy/paste the code in the SimpleJumpActionNewInputAction Script in this repo!
- Don't forget to assign the Serialize components in the inspector

- Helpful Pictures below:
- This is what my heirarchy looks like
- ![image](https://github.com/user-attachments/assets/30b08276-27c9-48f8-96c7-f1fdc6719bed)
- ![image](https://github.com/user-attachments/assets/31432098-1b7f-4142-a806-a717dd87c23b)
- ![image](https://github.com/user-attachments/assets/c14eb19f-b557-488b-b1a3-e880b69b4a4a)
- ![image](https://github.com/user-attachments/assets/9f8d7789-f0d8-44ef-a20e-776a56fd05a1)
- ![image](https://github.com/user-attachments/assets/07ffc468-4c19-486c-aea1-08bff6cc7098)

