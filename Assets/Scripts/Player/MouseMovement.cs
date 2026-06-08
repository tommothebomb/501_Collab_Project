using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Libby script \\
    [SerializeField] float mouseSense = 15;
    [SerializeField] Transform body;
    float xRotation;
    InputSystem_Actions inputActs;


    private void OnEnable()
    {
        inputActs = new InputSystem_Actions();
        inputActs.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnDisable() => inputActs.Player.Disable();

    private void LateUpdate()
    {
        // new input system stuff for mouse
        float mouseX = inputActs.Player.Look.ReadValue<Vector2>().x * mouseSense * Time.deltaTime;
        float mouseY = inputActs.Player.Look.ReadValue<Vector2>().y * mouseSense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        body.Rotate(Vector3.up * mouseX);
    }
}
