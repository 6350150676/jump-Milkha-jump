using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public Vector3 StartPos;
    public float RepeatWedith;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        RepeatWedith = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < StartPos.x - RepeatWedith)
        {
            transform.position = StartPos;
        }
    }
}
