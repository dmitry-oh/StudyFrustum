using System.Collections.Generic;
using UnityEngine;

public class QuadTree
{
    private readonly int capacity;
    private readonly Rect bounds;
    private List<GameObject> objects;
    private bool divided;

    private QuadTree northeast;
    private QuadTree northwest;
    private QuadTree southeast;
    private QuadTree southwest;

    public QuadTree(Rect bounds, int capacity)
    {
        this.bounds = bounds;
        this.capacity = capacity;
        this.objects = new List<GameObject>();
        this.divided = false;
    }

    public void Subdivide()
    {
        float x = bounds.x;
        float y = bounds.y;
        float w = bounds.width / 2;
        float h = bounds.height / 2;

        northeast = new QuadTree(new Rect(x + w, y, w, h), capacity);
        northwest = new QuadTree(new Rect(x, y, w, h), capacity);
        southeast = new QuadTree(new Rect(x + w, y + h, w, h), capacity);
        southwest = new QuadTree(new Rect(x, y + h, w, h), capacity);

        divided = true;
    }

    public bool Insert(GameObject obj)
    {
        Vector2 pos = obj.transform.position;
        if (!bounds.Contains(pos))
            return false;

        if (objects.Count < capacity)
        {
            objects.Add(obj);
            return true;
        }

        if (!divided)
            Subdivide();

        if (northeast.Insert(obj)) return true;
        if (northwest.Insert(obj)) return true;
        if (southeast.Insert(obj)) return true;
        if (southwest.Insert(obj)) return true;

        return false;
    }

    public List<GameObject> Query(Rect range, List<GameObject> found = null)
    {
        if (found == null)
            found = new List<GameObject>();

        if (!bounds.Overlaps(range))
            return found;

        foreach (var obj in objects)
        {
            Vector2 pos = obj.transform.position;
            if (range.Contains(pos))
                found.Add(obj);
        }

        if (divided)
        {
            northeast.Query(range, found);
            northwest.Query(range, found);
            southeast.Query(range, found);
            southwest.Query(range, found);
        }

        return found;
    }
    public void DrawGizmos()
{
    // Draw this node’s bounding box
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(
        new Vector3(bounds.center.x, bounds.center.y, 0),
        new Vector3(bounds.width, bounds.height, 0)
    );

    // Recursively draw children
    if (divided)
    {
        northeast.DrawGizmos();
        northwest.DrawGizmos();
        southeast.DrawGizmos();
        southwest.DrawGizmos();
    }
}

}
