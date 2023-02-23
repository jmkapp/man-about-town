using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private InputMaster _controls;
    private readonly float _moveSpeedRotation = 100f;
    private float _moveSpeed = 10f;
    private CharacterController _controller;

    void Awake()
    {
        _controls = new InputMaster();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = _controls.Player.Movement.ReadValue<Vector2>();
        PlayerMovement(move);
        Look(move);
    }

    // https://www.youtube.com/watch?v=w4IMYgpqgdQ

    private void PlayerMovement(Vector2 move)
    {
        Vector3 movement = (move.y * transform.forward);
        _controller.Move(movement * _moveSpeed * Time.deltaTime);
    }

    private void Look(Vector2 move)
    {
        float x = move.x * _moveSpeedRotation * Time.deltaTime;

        _controller.transform.Rotate(Vector3.up * x);
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
