using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if PLATFORM_IOS
using UnityEngine.iOS;
using UnityEngine.Apple.ReplayKit;


namespace LeafChage
{
    public class LiveStreaming : MonoBehaviour
    {
        [SerializeField] private Text streamingLabel;
        [SerializeField] private Text message;
        void Update()
        {
            this.streamingLabel.text = ReplayKit.isBroadcasting ? "StopStreaming" : "StartStreaming";
        }

        public void BackButtonTapped()
        {
            SceneManager.LoadScene("Test");
        }

        // streaming開始・終了のボタン
        public void Streaming()
        {

            // broadcastAPIを使えるかどうかの確認
            if (!ReplayKit.broadcastingAPIAvailable)
            {
				this.message.text = "I can not use broadcast";
                return;
            }

#if false
            // 音声を取れるかどうか確認
            if (!ReplayKit.microphoneEnabled)
            {
				this.message.text = "I can not use microphone";
                return;
            }
#endif

            if (ReplayKit.isBroadcasting)
            {
                // recording中の時は終了
                ReplayKit.StopBroadcasting();
            }
            else
            {
                ReplayKit.BroadcastStatusCallback callback = (bool success, string error) => { this.message.text = error; };
                // recording中でないときは開始
                // 第一引数はbroadcastの初期化時に呼ばれるReplayKit.BroadcastStatusCallback
                // 第二引数をtrueにするとマイクも拾える default = false
                // 第三引数は多分インカメ 
                ReplayKit.StartBroadcasting(callback, true);
            }
        }
    }
}
#endif