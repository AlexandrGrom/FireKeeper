using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Hands hands;
    private float xRotation = 0;

    void Awake()
    {
        JoystickManager.Instance.movingJoystic.DoubleTap += PickObject;
    }

    void Update()
    {
        float mouseY = JoystickManager.Instance.lookingJoystic.Vertical * JoystickManager.Instance.mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0,0);
    }

    private void PickObject()
    {
        hands.UseHands();  
    }
}
