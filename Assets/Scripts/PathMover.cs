using UnityEngine;
using System.Collections.Generic;

public class PathMover : MonoBehaviour
{
    private Transform player;

    private List<Transform> segments = new List<Transform>();
    private Vector3 startPos;
    private float speed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform)
        {
            segments.Add(child);
        }
        startPos = segments[segments.Count - 1].position;
        player = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform segment in segments)
        {
            Renderer rend = segment.GetComponent<Renderer>();
            Vector3 size = rend.bounds.size;
        
            if ((player.position.z + 37f) - segment.position.z > size.z - 7f) 
            { 
                segment.position = startPos;
            }
            segment.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    public void SpeedChanged(float gateSpeed) {
        speed = gateSpeed / 2;
    }
}
