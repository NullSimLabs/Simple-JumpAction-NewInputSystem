# Simple-JumpAction-NewInputSystem
Simple Unity jump system using Rigidbody with a SphereCast-based grounded check. Works with Unity's new Input System. Easy to drop into any project.

# Unity Jump System with Grounded Check

This is a simple example of a player jump system in Unity — using Rigidbody physics and a SphereCast-based grounded check to detect when the player is on the ground.

It also works with Unity's new Input System (InputAction.CallbackContext).

## Features

- Basic jump logic using Rigidbody.AddForce (Impulse)
- Ground detection with SphereCast (works better on uneven terrain than simple raycasts)
- Debug visual (green/red ray) to help you see grounded state in Scene view
- Easily adjustable jump height and ground radius
- Simple and lightweight — easy to drop into your own project

## Usage

Just copy the `IsGrounded()` function and `OnJumpPerformed()` function into your player controller script.

You’ll need:
- A Rigidbody on your player GameObject
- A CapsuleCollider (or similar) attached
- A jump input set up with Unity’s new Input System

## License

MIT — free to use in any project (personal or commercial). No attribution required.

---
