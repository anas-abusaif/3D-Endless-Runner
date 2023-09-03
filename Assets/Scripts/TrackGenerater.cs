using System.Collections.Generic;
using UnityEngine;

public class TrackGenerater : MonoBehaviour
{
    float TrackPosition = 100f;
    float PlayerPosition = 20f;
    float TrackDequeuePlayerPosition = 120f;
    [SerializeField] GameObject[] Tracks;
    public GameObject Player;
    Queue<GameObject> TracksQueue = new Queue<GameObject>();

    void Update()
    {
        if (Player.transform.position.z > PlayerPosition)
        {
            PlayerPosition += 20f;
            GameObject Track = Tracks[Random.Range(0, Tracks.Length)];
            TracksQueue.Enqueue(Instantiate(Track, new Vector3(0, 0, TrackPosition), Track.transform.rotation));
            TrackPosition += 20f;
        }
        if (Player.transform.position.z > TrackDequeuePlayerPosition)
        {
            TrackDequeuePlayerPosition += 20;
            Destroy(TracksQueue.Dequeue());
        }

    }
}
