using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    public float verticalSpeed = 2;
    public float horizontalSpeed = 5;
    public float jumpForce = 10;

    public float x, y, z;
    public float forceX, forceY, forceZ;

    public float gravity = 0.2f;

    private float _direction;

    private void Update()
    {
        if (z > 0)
        {
            z += forceZ * Time.deltaTime;
            forceZ -= gravity;

            if (z < 0) z = 0;
        }

        x += forceX * Time.deltaTime;
        y += forceY * Time.deltaTime;

        transform.localPosition = new Vector3(x, y + z, transform.localPosition.z);
    }

    public void MoveVertical(float vertical)
    {
        forceY = vertical * verticalSpeed;
    }

    public void MoveHorizontal(float horizontal)
    {
        forceX = horizontal * horizontalSpeed;
    }

    public void Jump()
    {
        forceZ = jumpForce;
        z += 0.1f;
    }

    public void ChangeDirection(float direction)
    {
        if (direction == 0) return;
        _direction = Mathf.Sign(direction);
        transform.localScale = new Vector3(_direction, 1, 1);
    }
}
