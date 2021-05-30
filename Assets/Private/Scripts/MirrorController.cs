using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    [SerializeField] private float max_velocity, velocity_decay;
    [SerializeField] private float max_x_coordinate, min_x_coordinate;

    private Transform _transform;
    private float current_velocity = 0;
    

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (_transform.position.x < min_x_coordinate && current_velocity < 0)
        {
            current_velocity = 0;
        }
        if (_transform.position.x > max_x_coordinate && current_velocity > 0)
        {
            current_velocity = 0;
        }

        _transform.position += new Vector3(current_velocity * Time.deltaTime, 0, 0);
        current_velocity *= velocity_decay;
    }

    private void OnTriggerEnter(Collider other)
    {
        SetVelocity(other);
    }

    private void OnTriggerStay(Collider other)
    {
        SetVelocity(other);
    }

    private void SetVelocity(Collider other)
    {
        if (other.tag == "Player")
        {
            float diff_x = other.transform.position.x - _transform.position.x;
            if (diff_x < 0)
            {
                // 鏡に対してキャラクターは左にいる
                current_velocity = max_velocity;
            }
            else
            {
                // 鏡に対してキャラクターは右にいる
                current_velocity = -max_velocity;
            }
        }
    }
}
