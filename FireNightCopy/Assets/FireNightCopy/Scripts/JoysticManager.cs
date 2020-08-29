using UnityEngine;

public class JoysticManager : MonoBehaviour
{
    [SerializeField] public FloatingJoystick lookingJoystic;
    [SerializeField] public FloatingJoystick movingJoystic;
    [SerializeField] public float mouseSensitivity;

    public static JoysticManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}
