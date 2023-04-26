using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float threshold = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // only follow player if they pass the threshold
        float distance = Vector3.Distance(transform.position, desiredPosition);
        if (distance > threshold)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
