using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    //DEFINE A VARIABLE FOR THE LINE RENDERER USED IN THE GAME
    public LineRenderer lr;

    private void Awake()
    {
        //ACCESS THE LINE RENDERER COMPONENT
        lr = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //FUNCTION TO DRAW LINE
    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        //HOW MANY POINTS IN THE LINE
        lr.positionCount = 2;
        //CREATE AN ARRAY FOR THE POINTS IN OUR LINE
        Vector3[] points = new Vector3[2];
        //FIRST VARIABLE IN THE ARRAY IS THE START POINT
        points[0] = startPoint;
        //SECOND VARIABLE IN THE ARRAY IS THE END POINT
        points[1] = endPoint;
        //ADDS THE TWO POINTS IN OUR ARRAY TO THE LINE
        lr.SetPositions(points);
    }

    public void EndLine()
    {
        //HELPS "ERASE" THE LINE BY REMOVING POINTS
        lr.positionCount = 0;
    }
}
