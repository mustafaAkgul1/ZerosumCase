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

	private List<MeshCollider> meshColliders;

	private void Start()
	{
		meshColliders = FindObjectsOfType<MeshCollider>().ToList();

	} // Start()

	private void Update()
	{
        foreach (MeshCollider meshColl in meshColliders)
        {
            for (int i = 0; i < meshColl.sharedMesh.vertices.Length; i++)
            {
				meshColl.sharedMesh.vertices[i] += Vector3.up * speed * Time.deltaTime;
			}
        }

	} // Update()

	// previous method was fetching a component reference in everyframe. fixed it.

} // class