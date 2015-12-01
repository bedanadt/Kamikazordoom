using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    //private float scrollspeed = 3f;
        public float xMin;
        public float xMax;
        public float yMin;
        public float yMax;
        public float cameraheight;
        public float camerawidth;
        public Vector3 initialpoint;

    // Update is called once per frame
    void Start()
    {
        cameraheight = 2f * Camera.main.orthographicSize;
        camerawidth = cameraheight * Camera.main.aspect;
        initialpoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        xMin = initialpoint.x;
        xMax = initialpoint.x + camerawidth;
        yMin = initialpoint.y;
        yMax = initialpoint.y + cameraheight;
    }
}
