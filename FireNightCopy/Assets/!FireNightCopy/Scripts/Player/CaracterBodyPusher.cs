using UnityEngine;

public class CaracterBodyPusher : MonoBehaviour
{
    [SerializeField] float pushPower;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody == null || rigidbody.isKinematic) return;
        if (hit.moveDirection.y < -.3f) return;

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rigidbody.velocity = pushPower * pushDirection;
    }
}
