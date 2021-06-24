using UnityEngine;

public class SplineWalker : MonoBehaviour
{

	public BezierSpline spline;

	public float duration;

	private float progress;

	public bool lookForward;

	public SplineWalkerMode mode;

	private bool goingForward = true;

	private void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{

			progress += Time.deltaTime / duration;
			if (progress > 1f)
			{
				if (mode == SplineWalkerMode.Once)
				{
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop)
				{
					progress -= 1f;
				}
				else
				{
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else if (Input.GetKey(KeyCode.S))
		{
			{
				progress -= Time.deltaTime / duration;
				if (progress < 0f)
				{
					if (mode == SplineWalkerMode.Loop)
					{
						progress = -1f;
					}
					progress = -progress;
					goingForward = true;
				}
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward)
		{
			transform.LookAt(position + spline.GetDirection(progress));
		}

		
	}
}