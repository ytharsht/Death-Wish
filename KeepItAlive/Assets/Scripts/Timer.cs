using UnityEngine;

public class Timer : MonoBehaviour
{
	public float startTime;
	private float timeLeft;
	[Space]
	public Death death;
	private void Start()
	{
		timeLeft = startTime;
	}
	private void Update()
	{
		timeLeft -= Time.deltaTime;

		if (timeLeft < 0)
		{
			StartCoroutine(death.KillPlayer());
		}
	}
}
