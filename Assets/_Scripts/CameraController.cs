using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private bool clampPosition;
    [SerializeField]
    private Vector2 xLimits, yLimits;
    
    [Header("Zoom")]
    [SerializeField]
    private bool clampZoom;
    [SerializeField]
    private float minZoom = 10f, maxZoom = 100f;

    [SerializeField]
    private float zoomSpeed = 250f, zoomIncrementByDistance = 0.5f;
    [SerializeField]
    private float moveSpeed = 0.1f, moveScale = 0.5f;

    private Camera theCamera;
    private Transform cameraTransform;
    private Vector3 startPos, endPos, direction, hey;

    void Start() {
        theCamera = GetComponent<Camera>();
        cameraTransform = theCamera.transform;
        hey = transform.position;
    }

    void Update() {
        if(PointerOnUI.Instance.IsPointerOverUIElement()) return;

        float zoomInput = Input.mouseScrollDelta.y;

        if(Input.GetMouseButtonDown(0)) {
            startPos = Input.mousePosition;
            hey = transform.position;
        }
        if(Input.GetMouseButton(0)) {
            endPos = Input.mousePosition;
            direction = endPos - startPos;
        }
        if(Input.GetMouseButtonUp(0)) {
            hey = transform.position;
            direction = Vector3.zero;
        }

        // Zooming
        theCamera.orthographicSize -= zoomInput * zoomSpeed * Time.deltaTime * theCamera.orthographicSize * zoomIncrementByDistance;
        
        if(clampZoom) theCamera.orthographicSize = Mathf.Clamp(theCamera.orthographicSize, minZoom, maxZoom);
        
        // Moving
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, hey - direction * moveScale, moveSpeed);
        
        if(clampPosition) {
            float clampedX = Mathf.Clamp(cameraTransform.position.x, xLimits.x, xLimits.y);
            float clampedY = Mathf.Clamp(cameraTransform.position.y, yLimits.x, yLimits.y);

           cameraTransform.position = new Vector3(clampedX, clampedY, cameraTransform.position.z);
        }
    }
}
