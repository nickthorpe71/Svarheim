using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    public PlayableDirector zoomInDirector;
    public PlayableDirector zoomOutDirector;

    public GameObject toServiceButton;
    public GameObject backToAppButton;

    public GameObject s1E1Label;

    // TODO:
    // make classes for:
    // - app (contains services and metadata)
    // - service (contains endpoints and metadata) all camera locations, ui, timelines
    // - endpoint (contains data) camera locations, ui, timelines

    // need to make this system:
    // 4 timelines (app2service, service2endpoint, endpoint2service, service2app)
    // ui elements hover over active objects depending which level you are at
    // when you click a ui element it takes you to the next level
    // the positions of cameras and data displayed on ui comes from class that matches current later and current target

    // need to implement ECS system
    // need to remove update function from AnchorUI component

    void Awake()
    {
        zoomInDirector.played += ZoomInPlayed;
        zoomOutDirector.played += ZoomOutPlayed;
    }

    private void ZoomInPlayed(PlayableDirector obj)
    {
        toServiceButton.SetActive(false);
    }

    private void ZoomOutPlayed(PlayableDirector obj)
    {
        backToAppButton.SetActive(false);
        s1E1Label.SetActive(false);
    }

    public void StartZoomIn()
    {
        zoomInDirector.Play();
        zoomOutDirector.Stop();

    }

    public void ArriveAtService()
    {
        backToAppButton.SetActive(true);
        s1E1Label.SetActive(true);
    }

    public void StartZoomOut()
    {
        zoomOutDirector.Play();
        zoomInDirector.Stop();
    }

    public void ArriveAtApp()
    {
        toServiceButton.SetActive(true);
    }
}
