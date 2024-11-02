using UnityEngine;

public class GameInputManager : MonoBehaviour
{
	private InputSystem_Actions inputActions;

	public static GameInputManager Singleton { get; private set; }

	private void Awake()
	{
		if (Singleton == null)
		{
			Singleton = this;
		}
		else
		{
			Debug.LogError("There are two instances of GameInputManager");
		}

		inputActions = new InputSystem_Actions();

		inputActions.Enable();
	}

	public Vector2 GetInputVector2()
	{
		return inputActions.Player.Move.ReadValue<Vector2>();
	}
}
