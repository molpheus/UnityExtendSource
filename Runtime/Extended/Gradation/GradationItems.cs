using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace com.molmolgames.U_Ex
{
    public class GradationItems : MonoBehaviour
    {
        [SerializeField] Image ColorBox = default;

        /// <summary> カラー情報 (R) </summary>
        [SerializeField] InputField RInput = default;
        /// <summary> カラー情報 (R) </summary>
        [SerializeField] Slider RSlider = default;

        /// <summary> カラー情報 (G) </summary>
        [SerializeField] InputField GInput = default;
        /// <summary> カラー情報 (G) </summary>
        [SerializeField] Slider GSlider = default;

        /// <summary> カラー情報 (B) </summary>
        [SerializeField] InputField BInput = default;
        /// <summary> カラー情報 (B) </summary>
        [SerializeField] Slider BSlider = default;

        /// <summary> カラー情報 (A) </summary>
        [SerializeField] InputField AInput = default;
        /// <summary> カラー情報 (A) </summary>
        [SerializeField] Slider ASlider = default;

        /// <summary> カラー位置設定 </summary>
        [SerializeField] InputField PInput = default;
        /// <summary> カラー位置設定 </summary>
        [SerializeField] Slider PSlider = default;

        /// <summary> 対象配列INDEX </summary>
        int index = 0;

        public UnityAction<int, GradationParam> onUpdateValue = null;
        GradationParam param = default;

        void Start ()
        {
            RInput.onValueChanged.AddListener (str => {
                if ( string.IsNullOrEmpty (str) ) { return; }
                RSlider.value = float.Parse (str) / 255f;
            });
            RSlider.onValueChanged.AddListener (value => {
                float val = Mathf.Lerp (0, 255, value);
                RInput.text = ( (int)val ).ToString ();
                param.color.r = value;
                UpdateValue ();
            });

            GInput.onValueChanged.AddListener (str => {
                if ( string.IsNullOrEmpty (str) ) { return; }
                GSlider.value = float.Parse (str) / 255f;
            });
            GSlider.onValueChanged.AddListener (value => {
                float val = Mathf.Lerp (0, 255, value);
                GInput.text = ( (int)val ).ToString ();
                param.color.g = value;
                UpdateValue ();
            });

            BInput.onValueChanged.AddListener (str => {
                if ( string.IsNullOrEmpty (str) ) { return; }
                BSlider.value = float.Parse (str) / 255f;
            });
            BSlider.onValueChanged.AddListener (value => {
                float val = Mathf.Lerp (0, 255, value);
                BInput.text = ( (int)val ).ToString ();
                param.color.b = value;
                UpdateValue ();
            });

            AInput.onValueChanged.AddListener (str => {
                if ( string.IsNullOrEmpty (str) ) { return; }
                ASlider.value = float.Parse (str);
            });
            ASlider.onValueChanged.AddListener (value => {
                AInput.text = ( value ).ToString ("F3");
                param.color.a = ASlider.value;
                UpdateValue ();
            });

            PInput.onEndEdit.AddListener (str => {
                if ( string.IsNullOrEmpty (str) ) { return; }
                PSlider.value = float.Parse (str) / 100f;
            });
            PSlider.onValueChanged.AddListener (value => {
                PInput.text = ( (int)Mathf.Lerp (0, 100f, value) ).ToString ();
                param.percent = int.Parse (PInput.text);
                UpdateValue ();
            });
        }

        public void Init (int index, GradationParam param)
        {
            this.index = index;
            this.param = param;
            ColorBox.color = this.param.color;
            RSlider.value = this.param.color.r;
            GSlider.value = this.param.color.g;
            BSlider.value = this.param.color.b;
            ASlider.value = this.param.color.a;
            PSlider.value = this.param.percent / 100f;

            RInput.text = Mathf.Lerp (0, 255, this.param.color.r).ToString ();
            GInput.text = Mathf.Lerp (0, 255, this.param.color.g).ToString ();
            BInput.text = Mathf.Lerp (0, 255, this.param.color.b).ToString ();
            AInput.text = this.param.color.a.ToString ();
            PInput.text = this.param.percent.ToString ();
        }

        void UpdateValue ()
        {
            //Debug.Log (param.ToString());
            ColorBox.color = this.param.color;
            onUpdateValue.Invoke (index, param);
        }

    }
}