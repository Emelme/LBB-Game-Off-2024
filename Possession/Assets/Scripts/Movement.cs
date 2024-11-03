using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	[SerializeField] private GameInput gameInputManager;
	[Space]
	[SerializeField] private Transform rightCheckTransform;
	[SerializeField] private Transform leftCheckTransform;
	[SerializeField] private Vector2 wallCheckSize;
	[SerializeField] private Transform bottomCheckTransform;
	[SerializeField] private Vector2 bottomCheckSize;
	[SerializeField] private LayerMask groundLayer;
	[Space]
	[SerializeField] private float moveSpeed;
	[SerializeField] private float accelerationSpeed;
	[SerializeField] private float decelerationSpeed;

	private Rigidbody2D rb;

	private Vector2 moveInput;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		moveInput = GameInput.Singleton.GetInputVector2();
	}

	private void FixedUpdate()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		float targetSpeed = moveInput.x * moveSpeed;
		float speedDifference = targetSpeed - rb.linearVelocityX;
		float velocityChangeSpeed = Mathf.Abs(targetSpeed) > 0.01f ? accelerationSpeed : decelerationSpeed;
		float movementForce = speedDifference * velocityChangeSpeed;

		rb.AddForce(movementForce * Vector2.right);
	}

	public bool OnGround()
	{
		return Physics2D.OverlapBox(bottomCheckTransform.position, bottomCheckSize, 0f, groundLayer);
	}
}
