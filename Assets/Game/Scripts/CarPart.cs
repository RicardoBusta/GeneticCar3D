using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshCollider), typeof(Rigidbody))]
public class CarPart : MonoBehaviour {
    public MeshFilter Filter;
    public MeshCollider Collider;
    public Rigidbody Body;
    public FixedJoint Joint;

    public void UpdateCarShape(bool flip, float angle1, float angle2, float rad1, float rad2, float width1, float width2,
        float carWidth) {
        Mesh mesh;
        (mesh = Filter.mesh).vertices = GenerateMesh(angle1, angle2, rad1, rad2, width1, width2, carWidth);
        Collider.sharedMesh = mesh;

        var partTransform = transform;
        partTransform.localScale = new Vector3(flip ? -1 : 1, 1, 1);
        partTransform.localPosition = Vector3.zero;
    }

    private static Vector3[] GenerateMesh(float angle1, float angle2, float rad1, float rad2, float width1,
        float width2,
        float carWidth) {
        var a1 = angle1 * Mathf.Deg2Rad;
        var a2 = angle2 * Mathf.Deg2Rad;

        var y1 = Mathf.Cos(a1) * rad1;
        var y2 = Mathf.Cos(a2) * rad2;

        var z1 = Mathf.Sin(a1) * rad1;
        var z2 = Mathf.Sin(a2) * rad2;

        // Mesh generated points
        var points = new Vector3[] {
            Vector3.zero, 
            new Vector3(0, y1, z1),
            new Vector3(0, y2, z2),
            new Vector3(carWidth, 0, 0),
            new Vector3(width1, y1, z1),
            new Vector3(width2, y2, z2),
        };

        // Mesh contains repeated points due to UV Mapping
        var mesh = new[] {
            points[0],
            points[2],
            points[1],
            points[3],
            points[4],
            points[5],
            points[0],
            points[3],
            points[2],
            points[5],
            points[2],
            points[5],
            points[4],
            points[1],
            points[0],
            points[4],
            points[3],
            points[1],
        };

        return mesh;
    }
}