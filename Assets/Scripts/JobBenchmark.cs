using UnityEngine;

/*
 *
 * JobBenchmark scene runs very slow because of the repeated dummy math operation below.
 * Implement the for loop below, using parallelized Unity jobs and Burst compiler to gain performance.
 * Is there a better math library for Burst jobs than UnityEngine.Mathf? 
 * If the 'count' is too large for your machine to handle, you can decrease it.
 * 
 */

public class JobBenchmark : MonoBehaviour
{
	[SerializeField]
	private bool useJob = false;

	private int count = 1000000;

	private float[] values;

	void Start()
	{
		values = new float[count];
	}

	void Update()
	{
		if (useJob)
		{
			// Job here
		}
		else
		{
			for (int i = 0; i < values.Length; i++)
			{
				values[i] = Mathf.Sqrt(Mathf.Pow(values[i] + 1.75f, 2.5f + i)) * 5 + 2f;
			}
		}
	}
}
