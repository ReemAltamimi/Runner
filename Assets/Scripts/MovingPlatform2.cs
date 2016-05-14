using UnityEngine;
using System.Collections;



class MovingPlatform2 : MonoBehaviour
{

    public Vector2 endOffset = Vector2.up;
    public float period = 2.0f;
    private Vector2[] endPoints = new Vector2[2];
    private float time;
    public void Start()
    {
        endPoints[0] = transform.position;
        endPoints[1] = endPoints[0] + endOffset;
    }

    public void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.position = Vector2.Lerp(endPoints[0], endPoints[1], 0.5f * (1+ Mathf.Sin(time / period)));
    }


}
