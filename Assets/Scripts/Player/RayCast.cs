using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
    Vector2[] shadowPoints;

    // Use this for initialization
    void Start () {
        shadowPoints = new Vector2[45];
    }
	
	// Update is called once per frame
	void Update () {
        var mPos = Input.mousePosition;
        mPos.z = 10;

        for (int i = 0; i < 45; i++) {
            Vector2 checker = new Vector2(Mathf.Cos(Mathf.Deg2Rad * i * 8), Mathf.Sin(Mathf.Deg2Rad * i * 8));
            shadowPoints[i] = LineCastColl(transform.position, checker * 10);
        }
        drawView(shadowPoints);
    }

    Vector2 LineCastColl(Vector2 thisPos, Vector2 endPos) {
        RaycastHit2D hit;
        
        hit = Physics2D.Linecast(thisPos, endPos, 1 << LayerMask.NameToLayer("Wall"));
        //Debug.DrawLine(thisPos, endPos, Color.green, 1 << LayerMask.NameToLayer("Wall"));
        if (hit.collider != null)
            return hit.point;
        else
            return endPos;
    }

    void drawView(params Vector2[] points) {
        for (int i = 0; i < points.Length; i++) {
            if (i == points.Length - 1) {
                if (points[i] != null && points[0] != null) {
                    Debug.DrawLine(points[i], points[0]);
                }
            } else
                if (points[i] != null && points[i + 1] != null)
                    Debug.DrawLine(points[i], points[i + 1]);
        }

    }

}


