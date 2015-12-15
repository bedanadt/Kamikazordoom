using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour
{
    public float amplitude = 2.0f;
    public float frequency = 0.5f;
    private float _frequency;
    private float phase = 0.0f;
    private float localY;
    private Transform trans;

	public float CustomTimer = 0f;

    void Start()
    {
        _frequency = frequency;
        trans = transform;
        localY = trans.position.y;
    }

    void Update()
    {
		CustomTimer += Time.deltaTime;
        if (frequency != _frequency)
            CalcNewFreq();

        Vector3 v3 = trans.position;
        v3.y = Mathf.Sin(CustomTimer * _frequency + phase) * amplitude + localY;
        trans.position = v3;
    }

    void CalcNewFreq()
    {
        float curr = (CustomTimer * _frequency + phase) % (2.0f * Mathf.PI);
        float next = (CustomTimer * frequency) % (2.0f * Mathf.PI);
        phase = curr - next;
        _frequency = frequency;
    }
}