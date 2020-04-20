using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target = null;
    private int wavepointIndex = 0;

    
    public float RotationSpeed = 4f;

    //values for internal use
   
    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.4f)
        {
            GetNextWaypoint();
            this.transform.LookAt(target);

            //Quaternion rotTarget = Quaternion.LookRotation(target.position - this.transform.position);

            //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, RotationSpeed * Time.deltaTime);
        }

        void GetNextWaypoint()
        {
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }

        
    }

}
