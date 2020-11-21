using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChanger : MonoBehaviour
{
    [SerializeField] Transform[] lanes;
    [SerializeField] float duration = 0.69f;
    [SerializeField] AnimationCurve curve = null;

    int currentLane = 1;
    Vector3 a, b;
    float elapsed = float.MaxValue;

    public void GoRight()
    {
        StartLerp(1);
    }
    
    public void GoLeft()
    {
        StartLerp(-1);
    }

    void StartLerp(in int target)
    {
        currentLane += target;
        currentLane = Mathf.Clamp(currentLane, 0, 2);

        enabled = true;
        elapsed = 0.0f;
        a = transform.localPosition;
        b = lanes[currentLane].localPosition;
    }
    void EndLerp()
    {
        enabled = false;

        transform.localPosition = b;
    }

    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = curve.Evaluate(elapsed / duration);

            transform.localPosition = Vector3.LerpUnclamped(a, b, t);
        }
        else
        {
            EndLerp();
        }
    }
}
