using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMesh : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var gameObject = new GameObject("MeshObject");
        gameObject.transform.SetParent(transform);
        gameObject.AddComponent<MeshRenderer>();
        var meshFilter = gameObject.AddComponent<MeshFilter>();
        var mesh = new Mesh();
        
        mesh.vertices = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
        };

        mesh.uv = new Vector2[] {
            new Vector2(0, 0),
            new Vector2(0, 0),
            new Vector2(0, 0),
            new Vector2(0, 0),
            new Vector2(0, 0),
            new Vector2(0, 0),
        };

        mesh.triangles = new[] {
            0, 1, 2,
            3, 4, 5
        };
        
        meshFilter.mesh = mesh;
    }
}
