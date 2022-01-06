using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject controlPanel;

    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += DirectorPlayed;
        director.stopped += DirectorStopped;
    }

    private void DirectorPlayed(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }

    private void DirectorStopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }

    public void StartTimeline()
    {
        director.Play();
    }
}
