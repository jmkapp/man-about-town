using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCubeProximityDetector : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_videoPlayer.isPlaying)
        {
            _videoPlayer.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (_videoPlayer.isPlaying)
        {
            _videoPlayer.Pause();
        }
    }
}
