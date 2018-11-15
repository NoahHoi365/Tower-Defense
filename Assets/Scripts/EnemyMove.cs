using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed = 5f;
    public float waitTime = .3f;
    public float turnSpeed = 90f;

    public Transform pathHolder;

    public delegate void EndOfPath();
    public event EndOfPath endOfPathEvent;

    void Start()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++) {
            waypoints[i] = pathHolder.GetChild(i).position;
        }

        StartCoroutine(FollowPath(waypoints));
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        StartCoroutine(TurnToFace(targetWaypoint));

        while (transform.position != waypoints[waypoints.Length - 1]) {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if(transform.position == targetWaypoint) {
                if (targetWaypointIndex < waypoints.Length - 1) {
                    targetWaypointIndex++;
                    targetWaypoint = waypoints[targetWaypointIndex];
                    yield return new WaitForSeconds(waitTime);
                    yield return StartCoroutine(TurnToFace(targetWaypoint));
                }
            }
            yield return null;
        }

        FindObjectOfType<MoneyScript>().EnemyHasReachedEnd();
        Destroy(gameObject);
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        var dirToLookTarget = lookTarget - transform.position;
        var angle = 180 + Mathf.Atan2(dirToLookTarget.y, dirToLookTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        yield return null;
    }

    void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach(Transform waypoint in pathHolder) {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
    }
}
