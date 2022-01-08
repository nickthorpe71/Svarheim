using UnityEngine;
using UnityEngine.Playables;

public class ServiceMapCamNav : MonoBehaviour
{
    public PlayableDirector appToService;
    public PlayableDirector serviceToApp;
    public PlayableDirector serviceToEndpoint;
    public PlayableDirector endpointToService;

    public GameObject[] appToServiceBtns;
    public GameObject serviceToAppBtn;
    public GameObject[] serviceToEndpointBtns;
    public GameObject endpointToServiceBtn;

    // public GameObject[] endpointLabels; // TODO: these labels will need to be instantiated and tied to correct endpoints UIAnchor

    void Awake()
    {
        appToService.played += AppToServicePlayed;
        serviceToApp.played += ServiceToAppPlayed;
        serviceToEndpoint.played += ServiceToEndpointPlayed;
        endpointToService.played += EndpointToServicePlayed;
    }

    private void AppToServicePlayed(PlayableDirector obj)
    {
        SetMultipleObjs(appToServiceBtns, false);
    }

    private void ServiceToAppPlayed(PlayableDirector obj)
    {
        SetMultipleObjs(serviceToEndpointBtns, false);
    }

    private void ServiceToEndpointPlayed(PlayableDirector obj)
    {
        serviceToAppBtn.SetActive(false);
    }

    private void EndpointToServicePlayed(PlayableDirector obj)
    {
        endpointToServiceBtn.SetActive(false);
    }

    // Button Actions
    public void StartAppToService()
    {
        StopAllDirectorsAndStart(appToService);
    }

    public void StartServiceToApp()
    {
        StopAllDirectorsAndStart(serviceToApp);
    }

    public void StartServiceToEndpoint()
    {
        StopAllDirectorsAndStart(serviceToEndpoint);
    }

    public void StartEndpointToService()
    {
        StopAllDirectorsAndStart(endpointToService);
    }

    // Arrival Signals
    public void ArriveAtApp()
    {
        SetMultipleObjs(appToServiceBtns, true);
    }

    public void ArriveAtService()
    {
        // set back to App button to true
        serviceToAppBtn.SetActive(true);

        // set all endpoint buttons to true
        SetMultipleObjs(serviceToEndpointBtns, true);

        // set all endpoint labels for this service true
        // SetMultipleObjs(endpointLabels, true);
    }

    public void ArriveAtEndpoint()
    {
        endpointToServiceBtn.SetActive(true);

        // TODO: will need to enable other UI here for endpoint close up
    }

    // TODO: move to utils class
    private void SetMultipleObjs(GameObject[] objs, bool setting)
    {
        foreach (GameObject obj in objs)
            obj.SetActive(setting);
    }

    private void StopAllDirectorsAndStart(PlayableDirector toPlay)
    {
        appToService.Stop();
        serviceToApp.Stop();
        serviceToEndpoint.Stop();
        endpointToService.Stop();

        toPlay.Play();
    }
}
