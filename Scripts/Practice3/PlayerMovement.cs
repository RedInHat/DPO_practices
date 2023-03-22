using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5.0f;
    [SerializeField] private float _jumpHeight = 1.0f;
    
    private readonly float _gravityValue = -9.81f;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    

    void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();
        _controller.minMoveDistance = 0f;
    }

    void Update()
    {
        _groundedPlayer = _controller.isGrounded;

        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(movement * Time.deltaTime * _playerSpeed);

        if (movement != Vector3.zero)
        {
            gameObject.transform.forward = movement;
        }

        if (Input.GetButtonDown("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
        transform.LookAt(movement + transform.position);

    }
}
