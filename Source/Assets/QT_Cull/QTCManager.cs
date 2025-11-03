using UnityEngine;
using System.Collections.Generic;

public class QTCManager : MonoBehaviour
{
    public Camera mainCamera;
    public List<GameObject> allObjects;
    public int capacity = 5;

    private QuadTree quadTree;

    void Update()
    {
        // Define the bounds of your world (you can adjust this)
        Rect worldBounds = new Rect(-50, -50, 100, 100);
        quadTree = new QuadTree(worldBounds, capacity);

        // Insert all objects into the tree
        foreach (var obj in allObjects)
        {
            quadTree.Insert(obj);
        }

        // Get camera view rectangle in world space
        Vector2 camPos = mainCamera.transform.position;
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;
        Rect cameraRect = new Rect(camPos.x - width / 2, camPos.y - height / 2, width, height);

        // Query visible objects
        List<GameObject> visibleObjects = quadTree.Query(cameraRect);

        // Enable only visible objects
        foreach (var obj in allObjects)
            obj.SetActive(false);

        foreach (var obj in visibleObjects)
            obj.SetActive(true);
    }
    void OnDrawGizmos()
{
    if (quadTree != null)
    {
        Gizmos.color = Color.green;
        quadTree.DrawGizmos();
    }
}

}
