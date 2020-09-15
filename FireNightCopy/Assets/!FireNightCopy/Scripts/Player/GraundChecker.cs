using UnityEngine;

public class GraundChecker : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    [SerializeField] private float graundDistace = 0.05f;


    void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, graundDistace);
    }
}
