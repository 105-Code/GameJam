using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform trackedObject;
    public float maxDistance = 10;
    public float moveSpeed = 20;
    public float updateSpeed = 10;
    [Range(4, 10)]
    public float currentDistance = 5;
    private string moveAxis = "Mouse ScrollWheel";
    private GameObject ahead;
    public float hideDistance = 1.5f;

    void Start()
    {
        ahead = new GameObject("ahead");

    }

    void LateUpdate()
    {
        this.ahead.transform.position = trackedObject.position + trackedObject.forward * (maxDistance * 0.25f);
        this.currentDistance += Input.GetAxisRaw(moveAxis) * moveSpeed * Time.deltaTime;
        this.currentDistance = Mathf.Clamp(currentDistance, 0, maxDistance);
        this.transform.position = Vector3.MoveTowards(transform.position, trackedObject.position + Vector3.up * currentDistance - trackedObject.forward * (currentDistance + maxDistance * 0.5f), updateSpeed * Time.deltaTime);
        this.transform.LookAt(ahead.transform);
 
    }
}
