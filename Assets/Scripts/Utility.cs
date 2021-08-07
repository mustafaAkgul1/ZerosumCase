using UnityEditor;
using UnityEngine;

/*
 * 
 * Complete the functions below.  
 * For sure, they don't belong in the same class. This is just for the test so ignore that.
 * 
 */

public static class Utility
{
	public static bool CheckCollision(Ray ray, float maxDistance, int layer)
	{
		/*
		 *	Perform a raycast using the ray provided, only to objects of the specified 'layer' within 'maxDistance' and return if something is hit. 
		 */

		int tmpLayerMask = 1 << layer;

        if (Physics.Raycast(ray, maxDistance, tmpLayerMask))
        {
			return true;
        }

		return false;
	}


	public static Vector2[] GeneratePoints(int size)
	{
		/*
		 * Generate 'size' number of random points, making sure they are distributed as evenly as possible (Trying to achieve maximum distance between every neighbor).
		 * Boundary corners are (0, 0) and (1, 1). (Point (1.2, 0.45) is not valid because it's outside the boundaries.)
		 * Is there a known algorithm that achieves this?
		 */

		float radius = 0.5f; // actually is (1,1) but it needs to be 0.5 for prevent negative pos.

		Vector2[] randomPoints = new Vector2[size];

		for (int i = 0; i < randomPoints.Length; i++)
		{
			var k = i + .5f;
			var r = Mathf.Sqrt((k) / size);
			var theta = Mathf.PI * (1 + Mathf.Sqrt(5)) * k;
			var x = r * Mathf.Cos(theta) * radius;
			var y = r * Mathf.Sin(theta) * radius;

			x += radius;
			y += radius;

			Vector2 tmpRandomPoint = new Vector2(x, y);
			randomPoints[i] = tmpRandomPoint;
		}

		return randomPoints;

		// i used fibonacci method here but there is randomized and more complex method called "Poisson Disc Sampling"
		// but i didnt implement it here because its too complicated.
	}


	public static Texture2D GenerateTexture(int width, int height, Color color)
	{
		/*
		 * Create a Texture2D object of specified 'width' and 'height', fill it with 'color' and return it. Do it as performant as possible.
		 */

		Texture2D texture = new Texture2D(width, height);

		for (int x = 0; x < texture.width; x++)
		{
			for (int y = 0; y < texture.height; y++)
			{
				texture.SetPixel(x, y, color);
			}
		}

		texture.Apply();

		return texture;
	}

	[MenuItem("GameObject/Select All Active", false, 1)]
	public static void SelectAllActiveGameObjects()
	{
		/*
		 * Implement this function so that it selects all the active GameObjects in the hierarchy window of the editor.
		 * Do it in a single line.
		 * It should be called through the Unity toolbar menu item "GameObject/Select All Active".
		 */

		Selection.objects = GameObject.FindObjectsOfType<GameObject>();
	}
}
