using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
	[SerializeField] private GameInputManager gameInputManager;

	[SerializeField] private Transform rightCheckTransform;
	[SerializeField] private Transform leftCheckTransform;
	[SerializeField] private Transform bottomCheckTransform;

	private Rigidbody2D rigidbody2d;

	private void Awake()
	{
		rigidbody2d = GetComponent<Rigidbody2D>();
	}
}
