using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using System.Threading.Tasks;
using Unity.Jobs;
using Unity.Collections;

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

	[Header("General Variables")]
	NativeArray<float> valuesWithJob;
	JobHandle calculationJobHandle;
	Calculation calculationJob;

	void Start()
	{
		values = new float[count];
		valuesWithJob = new NativeArray<float>(count, Allocator.Persistent);

	} // Start()

	void Update()
	{
		if (useJob)
		{
			calculationJob = new Calculation()
			{
				_valuesWithJob = valuesWithJob
			};

			calculationJobHandle = calculationJob.Schedule(valuesWithJob.Length, 64);
		}
		else
		{
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Mathf.Sqrt(Mathf.Pow(values[i] + 1.75f, 2.5f + i)) * 5 + 2f;
            }
        }

	} // Update()

	private void LateUpdate()
    {
		calculationJobHandle.Complete();

	} // LateUpdate()

	private void OnDestroy()
    {
		valuesWithJob.Dispose();

	} // OnDestroy()

	[BurstCompile]
    private struct Calculation : IJobParallelFor
    {
		public NativeArray<float> _valuesWithJob;

		public void Execute(int i)
        {
			_valuesWithJob[i] = Mathf.Sqrt(Mathf.Pow(_valuesWithJob[i] + 1.75f, 2.5f + i)) * 5 + 2f;

		} // Execute()

	} // struct

} // class
