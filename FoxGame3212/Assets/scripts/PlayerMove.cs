using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _speed;
    public float _jumpForce;
    public float _attachForce;
    public float _attachTime;

    private float _time;
    private bool _attached;

    private Rigidbody2D _rb;
    private Vector3 _movement;

    private void Start()
    {
       _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _movement.x = _speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movement.x = -_speed;
        }
        else
        {
            _movement.x = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movement.y = _jumpForce;
            _rb.velocity = _movement;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !_attached)
        {
            _attached = true;
            _time = 0;
        }
        if (_attached)
        {
            _time += Time.deltaTime;
            _movement.x = _attachForce;

            if (_time > _attachTime)
            {
                _attached = false;
            }
        }

        _movement.y = _rb.velocity.y;
        _rb.velocity = _movement;
    }
}