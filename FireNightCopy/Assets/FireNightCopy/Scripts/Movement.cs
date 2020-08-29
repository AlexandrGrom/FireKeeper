using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpHight = 3f;
    [SerializeField] private GraundChecker graundChecker;

    private CharacterController controller;
    private float gravity;

    void Awake()
    {
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
        if (Input.GetKeyDown(KeyCode.Space) && graundChecker.IsGrounded)
            gravity = Mathf.Sqrt(jumpHight * -2f * Physics.gravity.y);

        gravity += Physics.gravity.y * Time.deltaTime;
    }

    private void CalculateRotation()
    {
        float mouseX = JoysticManager.Instance.lookingJoystic.Horizontal * JoysticManager.Instance.mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    private Vector3 CalculateMovement() 
    {
        CalculateGravity();
        CalculateRotation();

        float x = JoysticManager.Instance.movingJoystic.Horizontal;
        float z = JoysticManager.Instance.movingJoystic.Vertical;
        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        move *= speed * Time.deltaTime;
        move.y = gravity * Time.deltaTime;
        return move;
    }
}
