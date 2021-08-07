using System.Collections;
using UnityEngine;

public class DelayedExecution : MonoBehaviour
{

	/*
	 * 
	 * Write the necessary code to make sure the commented line in the Start function compiles and works as intended.
	 * MyFunction should be called 2 seconds after the Delayed.Execute call.
	 * 
	 */

	private void Start()
	{
		// Delayed.Execute(MyFunction, 2f);

		//Option - 1
		Invoke("MyFunction", 2f);

		//Option - 2
		StartCoroutine(DelayedExecute(2f));
	}

	//Option - 2 Necessary Method
	IEnumerator DelayedExecute(float _delayTime)
    {
		yield return new WaitForSeconds(_delayTime);

		MyFunction();

	} // DelayedExecute()

	private void MyFunction()
	{
		Debug.Log("Executed with delay.");

	} // MyFunction()
} // class

