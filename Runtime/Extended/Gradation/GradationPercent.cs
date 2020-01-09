using UnityEngine;
using UnityEngine.UI;

namespace MolmolgamesEngine.U_Ex
{
    /// <summary>
    /// グラデーションのパーセント表示
    /// </summary>
    public class GradationPercent : MonoBehaviour
    {
        /// <summary> 表示域 </summary>
        [SerializeField] Text percent = default;
        /// <summary> パーセントで表示するか </summary>
        bool isPercent = true;
        /// <summary> パーセント </summary>
        int per = 0;
        /// <summary> 現在の値 </summary>
        float f = 0;

        public void SetTextObject (Text percent)
        {
            this.percent = percent;
        }

        /// <summary>
        /// パーセントデータを設定する
        /// </summary>
        /// <param name="per"> パーセント </param>
        /// <param name="isPercent"> パーセント表示するか </param>
        public void Set (int per, bool isPercent = true)
        {
            this.per = per;
            this.isPercent = isPercent;
            UpdateData (f);
        }

        /// <summary>
        /// 表示データの更新
        /// </summary>
        /// <param name="textData"> 現在の値 </param>
        public void UpdateData (float textData)
        {
            // パーセント表示の場合、何もしない
            if ( isPercent ) {
                if ( percent != null ) percent.text = per.ToString ();
                return;
            }
            else {
                f = textData;
                if ( per == 0 ) {
                    if ( percent != null ) percent.text = "0";
                }
                else {
                    float f = (per / 100f)* textData;
                    if ( percent != null ) percent.text = f.ToString ("F2");
                }
            }


        }
    }
}