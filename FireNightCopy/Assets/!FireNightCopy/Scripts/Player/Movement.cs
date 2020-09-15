using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpHight = 3f;
    [SerializeField] private GraundChecker graundChecker;

    private CharacterController controller;
    private float gravity;

    private void Start()
    {
        JoystickManager.Instance.lookingJoystic.DoubleTap += Jump;
        controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        controller.Move(CalculateMovement());
    }

    private void CalculateGravity()
    {
        if (graundChecker.IsGrounded && gravity < 0 ) 
            gravity = -2f;

        gravity += Physics.gravity.y * Time.deltaTime;
    }

    private void CalculateRotation()
    {
        float mouseX = JoystickManager.Instance.lookingJoystic.Horizontal * JoystickManager.Instance.mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    private Vector3 CalculateMovement() 
    {
        CalculateGravity();
        CalculateRotation();

        float x = JoystickManager.Instance.movingJoystic.Horizontal;
        float z = JoystickManager.Instance.movingJoystic.Vertical;

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        move *= speed * Time.deltaTime;
        move.y = gravity * Time.deltaTime;
        return move;
    }

    private void Jump()
    {
        if (graundChecker.IsGrounded) gravity = Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y);
    }
}
