using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class ImageTargetEvent : MonoBehaviour, ITrackableEventHandler
{
    public TrackableBehaviour trackable;
    public UnityEvent onTrackableFound;
    public UnityEvent onTrackableLost;

    void OnEnable()
    {
        trackable.RegisterTrackableEventHandler(this);
    }

    void OnDisable()
    {
        trackable.UnregisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            onTrackableFound.Invoke();
        }
        else
        {
            onTrackableLost.Invoke();
        }
    }
}
