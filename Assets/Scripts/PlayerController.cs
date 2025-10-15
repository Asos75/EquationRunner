using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 20.0f;

    public float leftBoundX = -7.5f;
    public float rightBoundX = 7.5f;

    private CharacterController controller;

    public InputActionReference moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Debug.Log("Initialized PlayerController");
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, 0);

        if(!(transform.position.x >= rightBoundX && move.x > 0) && !(transform.position.x <= leftBoundX && move.x < 0))
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

    }
}
