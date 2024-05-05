using System.Collections;
using UnityEngine;

public class GUIFramerate : MonoBehaviour
{
    private float timeToAverage = 10.0f;
    private int numberOfFrames = 0;
    private double frameTime = 0;
    private void Awake()
    {
        StartCoroutine(StartAfterTime(1.0f));
    }

    private void OnGUI()
    {
        // Create a new GUIStyle
        GUIStyle style = new GUIStyle(GUI.skin.label);

        // Set the font size
        style.fontSize = 40; // Change 20 to whatever size you prefer

        // Calculate the FPS text
        string text = "" + Mathf.RoundToInt(1 / Time.deltaTime);

        // Render the label with the modified style
        GUI.Label(new Rect(10, 10, 200, 40), text, style);
    }


    IEnumerator StartAfterTime(float time)
    {
        // Wait before starting
        yield return new WaitForSeconds(time);

        // Create a for loop that acts as the update method, calling each frame
        double length = timeToAverage;
        for (double i = 0; i < length; i += Time.deltaTime)
        {
            frameTime += Time.deltaTime;
            numberOfFrames++;
            yield return new WaitForEndOfFrame();
        }

        // Output average framerate over time
        Debug.Log("Average Framerate: " + 1 / (frameTime / numberOfFrames));
    }
}
