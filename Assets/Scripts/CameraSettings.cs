using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    [SerializeField] private Player player;

    private Camera mainCamera;

    private float maxX;
    private float maxY;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();

        Ray topLeftRay = mainCamera.ScreenPointToRay(Vector3.zero);
        Ray topRightRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width, 0, 0));
        Ray bottomLeftRay = mainCamera.ScreenPointToRay(new Vector3(0, Screen.height, 0));
        Ray bottomRightRay = mainCamera.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));

        float nearPlaneDistance = mainCamera.nearClipPlane;
        Vector3 topLeft = topLeftRay.GetPoint(nearPlaneDistance);
        Vector3 topRight = topRightRay.GetPoint(nearPlaneDistance);
        Vector3 bottomLeft = bottomLeftRay.GetPoint(nearPlaneDistance);
        Vector3 bottomRight = bottomRightRay.GetPoint(nearPlaneDistance);

        maxX = Mathf.Max(topLeft.x, topRight.x, bottomLeft.x, bottomRight.x);
        maxY = Mathf.Max(topLeft.y, topRight.y, bottomLeft.y, bottomRight.y);
    }

    private void Update()
    {

        if (player.transform.position.x - maxX < collider.bounds.min.x)
            transform.position = new Vector3(collider.bounds.min.x + maxX, mainCamera.transform.position.y, mainCamera.transform.position.z);

        if (player.transform.position.x + maxX > collider.bounds.max.x)
            transform.position = new Vector3(collider.bounds.max.x - maxX, mainCamera.transform.position.y, mainCamera.transform.position.z);

        if (player.transform.position.y - maxY < collider.bounds.min.y)
            transform.position = new Vector3(mainCamera.transform.position.x, collider.bounds.min.y + maxY, mainCamera.transform.position.z);

        if (player.transform.position.y + maxY > collider.bounds.max.y)
            transform.position = new Vector3(mainCamera.transform.position.x, collider.bounds.max.y - maxY, mainCamera.transform.position.z);
    }
}
