using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float xRotation = 0;

    void Update()
    {
        float mouseY = JoysticManager.Instance.lookingJoystic.Vertical * JoysticManager.Instance.mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);
    }
}
