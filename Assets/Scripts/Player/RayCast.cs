﻿using UnityEngine;
using System.Collections;


public class RayCast : MonoBehaviour
{
    Vector2[] shadowPoints;
    public int casts = 45;
    private int degreeOfCasts;

    // Use this for initialization
    void Start()
    {
        degreeOfCasts = 360 / casts;
        shadowPoints = new Vector2[casts];


        buildPointsAndMesh();

    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int t = 0;
        while (t < vertices.Length)
        {
            vertices[t] += normals[t] * Mathf.Sin(Time.time);
            t++;
        }
        // GetComponent<MeshFilter>().transform.position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        mesh.vertices = vertices;
        buildPointsAndMesh();
    }

    void buildPointsAndMesh()
    {
        for (int i = 0; i < casts; i++)
        {
            Vector2 checker = new Vector2(Mathf.Cos(Mathf.Deg2Rad * i * degreeOfCasts), Mathf.Sin(Mathf.Deg2Rad * i * degreeOfCasts));
            shadowPoints[i] = LineCastColl(transform.position, checker * 15);
        }
        buildMesh(shadowPoints);
    }


    Mesh buildMesh(params Vector2[] points)
    {
        // Use the triangulator to get indices for creating triangles
        Triangulator tr = new Triangulator(points);
        int[] indices = tr.Triangulate();

        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[points.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(points[i].x, points[i].y, 0);
        }

        // Create the mesh
        Mesh msh = new Mesh();
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.RecalculateNormals();
        msh.RecalculateBounds();


        MeshFilter mf = GetComponent<MeshFilter>();
        mf.mesh = msh;
        return msh;
    }

    Vector2 LineCastColl(Vector2 thisPos, Vector2 endPos)
    {
        RaycastHit2D hit;

        Vector2 endCheck = new Vector2(endPos.x + thisPos.x, endPos.y + thisPos.y);

        hit = Physics2D.Linecast(thisPos, endCheck, 1 << LayerMask.NameToLayer("Wall"));
        //Debug.DrawLine(thisPos, endCheck, Color.green);
        if (hit.collider != null)
            return hit.point - thisPos;
        else
            return endPos;
    }

    void drawView(params Vector2[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (i == points.Length - 1)
            {
                if (points[i] != null && points[0] != null)
                {
                    Debug.DrawLine(points[i], points[0]);
                }
            }
            else
                if (points[i] != null && points[i + 1] != null)
                Debug.DrawLine(points[i], points[i + 1]);
        }

    }

}


