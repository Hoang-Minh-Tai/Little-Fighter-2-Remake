using UnityEngine;

public class KeyboardController : MonoBehaviour, IController
{
    private const float DOUBLE_PRESS_TIME = 0.25f;

    private KeyCode _lastKeyPress;
    private float _lastPressTime;

    private void Update()
    {
        print(Input.GetKeyDown(KeyCode.A));
        if (Input.GetKeyDown(KeyCode.A))
        {
            _lastKeyPress = KeyCode.A;
            _lastPressTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _lastKeyPress = KeyCode.D;
            _lastPressTime = Time.time;
        }
    }

    public bool GetAction(Action action)
    {
        return Input.GetKey(GetActionKeyCode(action));
    }

    public bool GetActionDown(Action action)
    {
        return Input.GetKeyDown(GetActionKeyCode(action));
    }

    public bool GetActionUp(Action action)
    {
        return Input.GetKeyUp(GetActionKeyCode(action));
    }

    public float GetHorizontalAxis()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            return 1;
        }
        return 0;
    }

    public float GetMoveDoublePress()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_lastKeyPress == KeyCode.A && Time.time - _lastPressTime < DOUBLE_PRESS_TIME) return -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_lastKeyPress == KeyCode.D && Time.time - _lastPressTime < DOUBLE_PRESS_TIME) return 1;
        }
        return 0;
    }

    public float GetVerticalAxis()
    {
        if (Input.GetKey(KeyCode.S))
        {
            return -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            return 1;
        }
        return 0;
    }

    private KeyCode GetActionKeyCode(Action action)
    {
        return action switch
        {
            Action.Attack => KeyCode.J,
            Action.Jump => KeyCode.K,
            Action.Defend => KeyCode.L,
            _ => KeyCode.None,
        };
    }
}