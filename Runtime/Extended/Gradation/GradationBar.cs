using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MolmolgamesEngine.U_Ex
{
    /// <summary>
    /// グラデーションバー設定
    /// </summary>
    public class GradationBar : MonoBehaviour
    {
        [SerializeField] RectTransform area = default;
        /// <summary> ui list base </summary>
        [SerializeField] GameObject baseObject = default;
        /// <summary> 上部表示テキスト (最大値) </summary>
        [SerializeField] Text top = default;
        /// <summary> 下部表示テキスト (最小値) </summary>
        [SerializeField] Text bottom = default;

        /// <summary> ui list 上に作成したオブジェクトのリスト </summary>
        List<GameObject> gradationList = new List<GameObject>();

        /// <summary>  </summary>
        [SerializeField] bool isTopDown = true;

        [SerializeField] bool isPercent = true;

        private void Awake ()
        {
            area.anchorMin = new Vector2 (0.5f, 0.5f);
            area.anchorMax = new Vector2 (0.5f, 0.5f);
            area.sizeDelta = ( (RectTransform)transform ).sizeDelta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseObject"></param>
        public void SetBase (RectTransform area, GameObject baseObject)
        {
            this.area = area;
            this.baseObject = baseObject;
        }

        /// <summary>
        /// テキストオブジェクトの設定を行う
        /// </summary>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        public void SetTextObject (Text top, Text bottom)
        {
            this.top = top;
            this.bottom = bottom;
        }

        /// <summary>
        /// 上部表示テキスト内容の変更
        /// </summary>
        /// <param name="value"></param>
        public void SetHigh (float value)
        {
            top.text = value.ToString ();

            foreach ( var obj in gradationList ) {
                obj.GetComponent<GradationPercent> ().UpdateData (value);
            }
        }

        /// <summary>
        /// 下部表示テキスト内容の変更
        /// </summary>
        /// <param name="value"></param>
        public void SetLow (float value)
        {
            bottom.text = value.ToString ();
        }

        /// <summary>
        /// グラデーションバーの作成を行う
        /// </summary>
        /// <param name="colorList"> グラデーションリスト </param>
        public void SetColor (List<GradationParam> colorList)
        {
            foreach ( var obj in gradationList ) {
                obj.SetActive (false);
            }

            Transform parent = baseObject.transform.parent;
            float w = !isTopDown ? ((RectTransform)parent).sizeDelta.x : ((RectTransform)parent).sizeDelta.y;

            if ( ( colorList.Count - 1 ) == 1 ) {
                // 単色
                if ( gradationList.Count == 0 ) {
                    var obj = Instantiate(baseObject, parent);
                    gradationList.Add (obj);
                }
                if ( isTopDown ) gradationList[0].GetComponent<GradationMesh> ().SetColorUpDown (colorList[0].color, colorList[0].color);
                else gradationList[0].GetComponent<GradationMesh> ().SetColorLeftRight (colorList[0].color, colorList[0].color);
                gradationList[0].SetActive (true);

                ( (RectTransform)gradationList[0].transform ).sizeDelta = SetSize (
                    ( (RectTransform)parent ).sizeDelta,
                    !isTopDown ? GradationSpan (w, 0, 100) : ( (RectTransform)gradationList[0].transform ).sizeDelta.x,
                    isTopDown ? GradationSpan (w, 0, 100) : ( (RectTransform)gradationList[0].transform ).sizeDelta.y);


            }
            else {
                // データとしては１先のカラーデータが必要
                for ( int i = 0; i < colorList.Count - 1; i++ ) {
                    if ( gradationList.Count < ( i + 1 ) ) {
                        var obj = Instantiate(baseObject, parent);
                        obj.transform.SetAsFirstSibling ();
                        gradationList.Add (obj);
                    }
                    if ( isTopDown ) gradationList[i].GetComponent<GradationMesh> ().SetColorUpDown (colorList[i+1].color, colorList[i].color);
                    else gradationList[i].GetComponent<GradationMesh> ().SetColorLeftRight (colorList[i+1].color, colorList[i].color);
                    gradationList[i].SetActive (true);

                    int low = colorList[i].percent;
                    int max = colorList[i+1].percent;

                    ( (RectTransform)gradationList[i].transform ).sizeDelta = SetSize (
                        ( (RectTransform)parent ).sizeDelta,
                        !isTopDown ? GradationSpan (w, low, max) : ( (RectTransform)gradationList[i].transform ).sizeDelta.x,
                        isTopDown ? GradationSpan (w, low, max) : ( (RectTransform)gradationList[i].transform ).sizeDelta.y);

                    if ( gradationList[i].GetComponent<GradationPercent> () != null ) {
                        gradationList[i].GetComponent<GradationPercent> ().Set (low, isPercent);
                    }

                }
            }
        }

        /// <summary>
        /// データの設定を行う
        /// </summary>
        /// <param name="size"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vector2 SetSize (Vector2 size, float x, float y)
        {
            //Debug.Log (size + " : " + x + " ," + y);
            size.x = x;
            size.y = y;
            return size;
        }

        /// <summary>
        /// 対象範囲の高さ計算
        /// </summary>
        /// <param name="wight"></param>
        /// <param name="lowPer"></param>
        /// <param name="maxPer"></param>
        /// <returns></returns>
        public float GradationSpan (float wight, int lowPer, int maxPer)
        {
            //Debug.Log (wight + " : " + lowPer + " : " + maxPer);
            float low = wight * (lowPer / 100f);
            float max = wight * (maxPer / 100f);
            //Debug.Log (low + " : " + max);
            return Mathf.Abs (low - max);
        }
    }
}