using UnityEngine;
using System.Collections;

public class timeKeeping : MonoBehaviour {

    float timeSinceStart;

	// Use this for initialization
	void Start () {
        
        timeSinceStart = 0;
	}

    void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(10, 425, 200, 140), "Survival Time: " + timeSinceStart);
    }

    void ResetTimer()
    {
        timeSinceStart = 0;
    }

    // Update is called once per frame
    void Update () {
        timeSinceStart += Time.deltaTime;
    }
}
