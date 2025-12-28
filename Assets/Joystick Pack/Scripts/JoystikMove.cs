using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public static JoystickMove Instance;
    public Joystick movementJoystick;

    public float Horizontal { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (movementJoystick == null)
        {
            Horizontal = 0;
            return;
        }

        float x = movementJoystick.Horizontal;

        // Deadzone
        if (Mathf.Abs(x) < 0.1f)
            x = 0;

        Horizontal = x;
    }
}
