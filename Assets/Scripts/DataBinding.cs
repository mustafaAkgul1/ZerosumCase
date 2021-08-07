using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*
 * 
 * Assume that you have created the class 'Data' for some reason and you are processing some data inside it. The output is float 'data'.
 * Then you realized you have to show this variable on the screen via a UnityEngine.Text, using the class 'TextSetter' you have written.
 * It updates the text whenever the data changes.
 * Data and TextSetter classes have no means of communication. They can't use references of each other.
 * In addition, you liked the TextSetter class a lot and want to use it in different places with different types of data later on. You want to generalize your technique.
 * 
 * Writing a global manager class that handles the classes below is not an option.
 * 
 * Static access to data classes is not the answer.
 * 
 * How would you solve this? Is there a behavioural pattern that seems to be the answer?
 * 
 * You can implement anything you wish.
 * 
 * Your solution doesn't actually have to work, just make sure your solution and intentions are clear conceptually.
 * 
 */

[System.Serializable]
public class EventsManager : UnityEvent<float>
{
	// it can be "<T>" type so transfer any type of parameter but i couldnt do that right now.

} // class

public class Data : MonoBehaviour
{
	private float data = 0f;
	EventsManager TextUpdaterEvent = new EventsManager();

	private void Update()
	{
		data += Time.deltaTime * 5f;
		TextUpdaterEvent.Invoke(data);

	} // Update()

} // class


public class TextSetter : MonoBehaviour
{
	EventsManager TextUpdaterEvent = new EventsManager();

	[SerializeField]
	private Text text;

    private void OnEnable()
    {
		TextUpdaterEvent.AddListener(UpdateTextValue);

	} // OnEnable()

	private void OnDisable()
	{
		TextUpdaterEvent.RemoveListener(UpdateTextValue);

	} // OnDisable()

	private void UpdateTextValue(float _value)
    {
		text.text = _value.ToString();

	} // UpdateTextValue ()

} // class
