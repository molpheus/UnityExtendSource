using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MolmolgamesEngine.U_Ex
{
    /// <summary>
    /// グラデーションの設定
    /// </summary>
    public class GradationSettings : MonoBehaviour
    {
        #region OpenListWindow
        /// <summary> 基本ウィンドウのオブジェクト </summary>
        [SerializeField] GameObject baseParent = default;

        /// <summary>
        /// ウィンドウを開く
        /// </summary>
        public void OpenWindow ()
        {
            baseParent.SetActive (true);
            Init ();
        }

        /// <summary>
        /// ウィンドウを閉じる
        /// </summary>
        public void CloseWindow ()
        {
            baseParent.SetActive (false);
            gradation.Submit ();
        }
        #endregion
        /// <summary> グラデーション </summary>
        [SerializeField] Gradation gradation = default;

        /// <summary> グラデーションバー </summary>
        [SerializeField] GradationBar bar = default;
        /// <summary> プレハブ </summary>
        [SerializeField] GameObject prefab = default;

        /// <summary> 生成したプレハブリスト </summary>
        List<GameObject> objList = new List<GameObject>();
        /// <summary> グラデーションパラメータリスト </summary>
        List<GradationParam> paramList = new List<GradationParam>();

        public void Init ()
        {
            foreach ( var obj in objList ) {
                obj.SetActive (false);
            }

            // 該当のファイルは起動時に絶対生成されるのでチェック不要
            // Gradation.cs 参照
            string path = Path.Combine(Application.streamingAssetsPath, "gradation.txt");


            string text = File.ReadAllText(path);
            string[] lineList = text.Split(System.Environment.NewLine.ToCharArray());
            paramList.Clear ();
            for ( int i = 1; i < lineList.Length; i++ ) {
                // 先頭文字が数値の場合のみ処理を行う
                if ( lineList[i].Length != 0 && ( lineList[i][0] >= '0' && lineList[i][0] <= '9' ) ) {
                    string[] sp = lineList[i].Split(','); // カンマ区切りで分割
                                                          // 必要数なければ処理をしない
                                                          //Debug.Log (sp.Length);
                    if ( sp.Length < 5 ) { continue; }

                    // データの取得
                    float R = sp.Length > 0 ? float.Parse( sp[0] ) : 0; // 0 ~ 255
                    float G = sp.Length > 1 ? float.Parse( sp[1] ) : 0; // 0 ~ 255
                    float B = sp.Length > 2 ? float.Parse( sp[2] ) : 0; // 0 ~ 255
                    float A = sp.Length > 3 ? float.Parse( sp[3] ) : 0; // 0 ~ 1
                    int P = sp.Length > 4 ? int.Parse( sp[4] ) : 0; // 0 ~ 100

                    // 範囲内に収める
                    R = Mathf.Clamp (R, 0, 255);
                    G = Mathf.Clamp (G, 0, 255);
                    B = Mathf.Clamp (B, 0, 255);
                    A = Mathf.Clamp (A, 0, 1);
                    P = Mathf.Clamp (P, 0, 100);

                    GradationParam param = new GradationParam();
                    param.color = new Color (R/ 255.0f, G / 255.0f, B / 255.0f, A);
                    param.percent = P;
                    paramList.Add (param);
                }
            }

            // 現在設定の更新
            bar.SetColor (paramList);

            // 調整用のデータリストの作成
            for ( int i = 0; i < paramList.Count; i++ ) {
                if ( objList.Count < ( i+1 ) ) {
                    var obj = Instantiate(prefab, prefab.transform.parent);
                    objList.Add (obj);
                }
                objList[i].SetActive (true);

                objList[i].GetComponent<GradationItems> ().Init (i, paramList[i]);
                objList[i].GetComponent<GradationItems> ().onUpdateValue = UpdateGradationData;
            }

        }

        /// <summary>
        /// グラデーションパラメータの変更を適応する
        /// </summary>
        /// <param name="index"></param>
        /// <param name="param"></param>
        void UpdateGradationData (int index, GradationParam param)
        {
            //Debug.Log ("target index : " + index);

            paramList[index] = param;

            // ソートは別な枠で行う
            List<GradationParam> newParam = new List<GradationParam>(paramList);
            newParam.Sort ((o1, o2) => {
                if ( o1 == null && o2 == null ) return 0;
                if ( o1 == null && o2 != null ) return -1;
                if ( o1 != null && o2 == null ) return 1;

                if ( o1.percent < o2.percent ) return -1;
                if ( o1.percent > o2.percent ) return 1;

                return 0;
            });

            //for(int i = 0; i < newParam.Count; i++ ) {
            //    Debug.Log ("data : " + newParam[i].ToString());
            //}

            // 現在設定の更新
            bar.SetColor (newParam);
        }

        /// <summary>
        /// グラデーションパラメータを保存する
        /// </summary>
        public void Submit ()
        {
            // ソートは別な枠で行う
            List<GradationParam> newParam = new List<GradationParam>(paramList);
            newParam.Sort ((o1, o2) => {
                if ( o1 == null && o2 == null ) return 0;
                if ( o1 == null && o2 != null ) return -1;
                if ( o1 != null && o2 == null ) return 1;

                if ( o1.percent < o2.percent ) return -1;
                if ( o1.percent > o2.percent ) return 1;

                return 0;
            });

            string saveData = "R,G,B,A,P\n";
            for ( int i = 0; i < newParam.Count; i++ ) {
                saveData = string.Format ("{0}{1},{2},{3},{4},{5}\n",
                    saveData,
                    (int)Mathf.Lerp (0, 255, newParam[i].color.r),
                    (int)Mathf.Lerp (0, 255, newParam[i].color.g),
                    (int)Mathf.Lerp (0, 255, newParam[i].color.b),
                    (int)Mathf.Lerp (0, 1, newParam[i].color.a),
                    newParam[i].percent
                );
            }

            string path = Path.Combine(Application.streamingAssetsPath, "gradation.txt");
            File.WriteAllText (path, saveData);

            CloseWindow ();
        }
    }
}