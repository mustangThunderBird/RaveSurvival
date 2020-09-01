using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColorYellowAndGreen : MonoBehaviour
{
    Light lt;
    float duration = 5.0f;
    Color yellow = Color.yellow;
    Color green = Color.green;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float tim = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(yellow, green, tim);
        transform.Rotate(0, 1f, 0);
    }
}
