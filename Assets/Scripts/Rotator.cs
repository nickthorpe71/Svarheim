using UnityEngine;

public class Rotator : MonoBehaviour
{
    [HideInInspector] public Vector3 rotation;

    // This is just for demo
    // TODO: switch out for ECS

    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
