using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdgeCollider : MonoBehaviour
{
    private void Awake()
    {
        AddColliderOnCamera();
    }

    public void AddColliderOnCamera()
    {
        Camera cam = Camera.main;

        // Get or Add Edge Collider 2D component
        var edgeCollider = gameObject.GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : gameObject.GetComponent<EdgeCollider2D>();

        // Making camera bounds
        var leftBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        var leftTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var rightTop = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        var rightBottom = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

        var edgePoints = new[] { leftBottom, leftTop, rightTop, rightBottom, leftBottom };

        // Adding edge points
        edgeCollider.points = edgePoints;
    }
}
