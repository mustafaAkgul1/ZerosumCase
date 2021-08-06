using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * The following code is written poorly in terms of performance.
 * Find the all problems, critical or micro-optimization, and mark them. Suggest fixes if you can.
 */

public class Optimization : MonoBehaviour
{
	public float speed = 1f;

	private List<MeshFilter> meshFilters;

	private void Start()
	{
		meshFilters = new List<MeshFilter>();

		meshFilters.AddRange(FindObjectsOfType<MeshFilter>().ToList());
	}

	private void Update()
	{
		foreach (var meshFilter in meshFilters)
		{
			if (meshFilter.GetComponentInChildren<MeshCollider>())
			{
				for (var i = 0; i < meshFilter.mesh.vertices.Length; i++)
				{
					meshFilter.mesh.vertices[i] += Vector3.up * speed * Time.deltaTime;
				}
			}
		}
	}
}