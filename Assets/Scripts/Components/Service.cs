using UnityEngine;
using System.Collections.Generic;

public class Service : MonoBehaviour
{
    // Generic Data
    public new string name;
    public List<Service> dependencies;
    public List<Endpoint> endpoints;

    // Game Data
    public Vector3 skyCamPos;
    public GameObject skyCamLookAt;
    public Vector3 groundCamPos;
    public GameObject groundCamLookAt;
}
