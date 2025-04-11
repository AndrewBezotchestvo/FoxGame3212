using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _attachForce;
    [SerializeField] private float _attachTime;

    private float _time;
    private bool _attached;
    private bool _isGround;

    private Rigidbody2D _rb;
    private Vector3 _movement;

    private void Start()
    {
        _isGround = true;
       _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _movement.x = _speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movement.x = -_speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _movement.x = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _isGround = false;
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

            if(transform.rotation.y == 0)
            {
                _movement.x = _attachForce; 
            }
            else
            {
                _movement.x = -_attachForce;
            }

            if (_time > _attachTime)
            {
                _attached = false;
            }
        }

        _movement.y = _rb.velocity.y;
        _rb.velocity = _movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            _isGround = true;
        }
    }
}