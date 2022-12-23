/*using UnityEngine;

public class Zooming : MonoBehaviour
{
    public float minCamFOV;
    public float maxCamFOV;

    public Camera camera;
    private float targetZoom;
    private float ZoomFactor = 2f;
    private float zoomLerpSpeed = 10f;
    private float zoomData = 0;
    public RPM rpm;
    public Speedometer speedometer;

    void Start()
    {
        camera = this.GetComponent<Camera>();
        targetZoom = camera.orthographicSize;
    }
    private void Update()
    {
        camera.orthographicSize = rpm.Speed / 37;
        if (Input.GetKey(KeyCode.W) == false)
            camera.orthographicSize = -1f;
        Debug.Log(camera.orthographicSize);
        targetZoom = zoomData * ZoomFactor;
        camera.orthographicSize = Mathf.Clamp(Mathf.Lerp(camera.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed), minCamFOV, maxCamFOV);
    }
}
*/