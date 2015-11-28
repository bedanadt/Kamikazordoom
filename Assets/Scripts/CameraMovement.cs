using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    private float scrollspeed = 3f;
	
	// Update is called once per frame
	void FixedUpdate () {
        //float position = scrollspeed * Time.deltaTime;
        //transform.Translate (new Vector3(position, 0, 0));

        Debug.Log("XMin: " + Camera.main.rect.xMin + "\nYMin: " + Camera.main.rect.yMin);
        Debug.Log("XMax: " + Camera.main.rect.xMax + "\nYMax: " + Camera.main.rect.yMax);
        Debug.Log(Camera.main.ScreenToWorldPoint(Vector3.zero));
    }
}
