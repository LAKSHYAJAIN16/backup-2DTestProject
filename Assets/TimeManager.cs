using UnityEngine;

public class TimeManager : MonoBehaviour
{

	public float slowdownFactor = 0.05f;
	public float slowdownLength = 2f;

	public GameObject SLowMotionPostProccessing;

	void Update()
	{
		Time.timeScale += (1.0f / slowdownLength) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
		if (Time.timeScale == 1.0f)
		{
			Time.fixedDeltaTime = Time.deltaTime;
		}

        //Input
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
			DoSlowmotion();
        }
	}

	public void DoSlowmotion()
	{
		SLowMotionPostProccessing.SetActive(true);
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
		Debug.Log("SLOW MOTION");
		Invoke("Reset", slowdownLength);
	}

	private void Reset()
    {
		SLowMotionPostProccessing.SetActive(false);
    }

}