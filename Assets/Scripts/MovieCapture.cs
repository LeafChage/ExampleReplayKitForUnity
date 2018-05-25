using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if PLATFORM_IOS
using UnityEngine.iOS;
using UnityEngine.Apple.ReplayKit;

namespace LeafChage
{
    public class MovieCapture : MonoBehaviour
    {
        [SerializeField] private Text recordButtonLabel;
        [SerializeField] private Text errorText;
        [SerializeField] private Button previewButton;
        [SerializeField] private Button discardButton;

        void Update()
        {
            this.recordButtonLabel.text = ReplayKit.isRecording ? "Stop Recording" : "Start Recording";
            this.previewButton.gameObject.SetActive(ReplayKit.recordingAvailable);
            this.discardButton.gameObject.SetActive(ReplayKit.recordingAvailable);
        }

        public void BackButtonTapped()
        {
            SceneManager.LoadScene("Test");
        }

        public void Record()
        {
            // ReplayKitのAPIが使えるような環境
            if (!ReplayKit.APIAvailable)
            {
                this.errorText.text = "I can not replaykit";
                return;
            }

#if false
            // 音声を取れるかどうか確認
            if (!ReplayKit.microphoneEnabled)
            {
                this.errorText.text = "I can not use microphone";
                return;
            }
#endif

            try
            {
                if (ReplayKit.isRecording)
                {
                    // recording中の時はStopRecording
                    ReplayKit.StopRecording();
                }
                else
                {
                    //recordingしていない時はStartRecordingをする
                    // 第一引数をtrueにするとマイクも拾える default = false
                    // 第二引数は多分インカメ 
                    ReplayKit.StartRecording(true);
                }
            }
            catch (Exception e)
            {
                this.errorText.text = e.ToString();
            }
        }

        // 動画のpreviewをする
        public void Preview()
        {
            ReplayKit.Preview();
        }

        // 多分 溜まっている動画を捨てる
        public void Discard()
        {
            ReplayKit.Discard();
        }
    }
}
#endif