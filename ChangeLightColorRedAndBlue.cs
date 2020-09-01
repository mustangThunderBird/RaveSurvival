using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColorRedAndBlue : MonoBehaviour
{
    Light lt;
    float duration = 1.0f;
    Color red = Color.red;
    Color blue = Color.blue;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float tim = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(red, blue, tim);
        transform.Rotate(0, -.5f, 0);
    }
}
