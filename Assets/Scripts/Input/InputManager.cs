using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private void Awake()
    {
        this.playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        this.UpdateActions();
    }

    private void UpdateActions()
    {
        this.movement = this.playerInput.actions["Move"].ReadValue<Vector2>().normalized;
        this.left = this.movement.x < 0;
        this.right = this.movement.x > 0;

        this.firePressed = this.playerInput.actions["Fire"].WasPressedThisFrame();
        
        this.restartPressed = this.playerInput.actions["Restart"].WasPressedThisFrame();
    }

    // Input Actions Asset
    private PlayerInput playerInput;

    // Move "WASD"
    public Vector2 movement {get; private set;}
    public bool left {get; private set;}
    public bool right {get; private set;}

    // Fire "Space"
    public bool firePressed {get; private set;}

    // Restart "R"
    public bool restartPressed {get; private set;}
}
