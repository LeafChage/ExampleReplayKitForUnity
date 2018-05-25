using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LeafChage
{
    public class Test : MonoBehaviour
    {
        public void ToMovieCaptureScene()
        {
            SceneManager.LoadScene("MovieCapture");
        }

        public void ToLiveStreamingScene()
        {
            SceneManager.LoadScene("LiveStreaming");
        }
    }
}