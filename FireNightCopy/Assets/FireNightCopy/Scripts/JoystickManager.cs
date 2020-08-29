using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    [SerializeField] public FloatingJoystick lookingJoystic;
    [SerializeField] public FloatingJoystick movingJoystic;
    [SerializeField] public float mouseSensitivity;


    public static JoystickManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

}
