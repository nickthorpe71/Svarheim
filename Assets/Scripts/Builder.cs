using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Data;

public class Builder : MonoBehaviour
{

    // TODO:
    // need to implement ECS system
    // need to remove update function from AnchorUI component

    // ************ These are being assigned manually for now *************
    // TODO: will need to instantiate these depending on the data passed
    // which will take in data and generate gameObjects in scene
    // at that point this WONT NEED TO BE A MONOBEHAVIOUR and can be removed from the scene and placed in its own namespace
    public GameObject app;

    private Dictionary<string, GameObject> allServices = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> endpoints = new Dictionary<string, GameObject>();

    public GameObject service1;
    public GameObject s1Endpoint1;

    public GameObject service2;
    public GameObject s2Endpoint1;
    public GameObject s2Endpoint2;

    public GameObject service3;
    public GameObject s3Endpoint1;
    public GameObject s3Endpoint2;
    public GameObject s3Endpoint3;
    // ************************************************************************

    // entire Awake method can be removed once we are generating gameObjects
    private void Awake()
    {
        allServices["Service1"] = service1;
        allServices["Service2"] = service2;
        allServices["Service3"] = service3;
        endpoints["S1-Endpoint1"] = s1Endpoint1;
        endpoints["S2-Endpoint1"] = s2Endpoint1;
        endpoints["S2-Endpoint2"] = s2Endpoint2;
        endpoints["S3-Endpoint1"] = s3Endpoint1;
        endpoints["S3-Endpoint2"] = s3Endpoint2;
        endpoints["S3-Endpoint3"] = s3Endpoint3;

    }

    public App BuildApp(AppModel appData)
    {
        // TODO: instantiate appObj
        GameObject appObj = app;

        App appScript = appObj.GetComponent<App>();

        // name is set in inspector as well as in component data
        appObj.name = appData.Name;
        appScript.name = appData.Name;
        appScript.camPos = new Vector3(340, 3471.28f, 240);

        appScript.services = new Dictionary<string, Service>();
        foreach (ServiceModel service in appData.Services)
            appScript.services[service.Name] = BuildService(service);

        // Need to assign dependencies to services after they are all generated
        AssignServiceDependencies(appData.Services, appScript.services);

        return appScript;
    }

    private Service BuildService(ServiceModel serviceData)
    {
        // TODO: procedurally generate serviceObj based on data / type etc.
        GameObject serviceObj = allServices[serviceData.Name];

        Service serviceScript = serviceObj.GetComponent<Service>();

        serviceObj.name = serviceData.Name;
        serviceScript.name = serviceData.Name;
        Vector3 pos = serviceObj.transform.position;
        serviceScript.groundCamPos = new Vector3(pos.x + 89, pos.y + 143, pos.z - 52);
        serviceScript.skyCamPos = new Vector3(pos.x + 300, pos.y + 2900, pos.z);
        serviceScript.endpoints = serviceData.Endpoints.Select(endpoint => BuildEndpoint(endpoint)).ToList();

        return serviceScript;
    }

    private Endpoint BuildEndpoint(EndpointModel endpointData)
    {
        // TODO: procedurally generate endpoint based on data / level etc.
        GameObject endpointObj = endpoints[endpointData.Name];

        Endpoint endpointScript = endpointObj.GetComponent<Endpoint>();

        endpointObj.name = endpointData.Name;
        endpointScript.name = endpointData.Name;
        Vector3 pos = endpointObj.transform.position;
        endpointScript.camPos = new Vector3(pos.x, pos.y, pos.z);

        return endpointScript;
    }

    private void AssignServiceDependencies(ServiceModel[] services, Dictionary<string, Service> serviceObjs)
    {
        foreach (KeyValuePair<string, Service> service in serviceObjs)
            service.Value.dependencies = GetServiceDependencies(services, service.Key, serviceObjs);
    }

    private List<Service> GetServiceDependencies(ServiceModel[] services, string serviceName, Dictionary<string, Service> serviceObjs)
    {
        // get this services data
        ServiceModel thisServiceData = services.Where(service => service.Name == serviceName).First();

        // get dependencies
        ServiceModel[] dependencies = thisServiceData.Dependencies;

        // get correct dependencies from service Objs
        return dependencies.Select(dependency => serviceObjs[dependency.Name]).ToList();
    }

}
