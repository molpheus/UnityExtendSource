using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// グラデーション
/// </summary>
public class Gradation : MonoBehaviour
{
    [System.Serializable]
    public class GradientEvent : UnityEngine.Events.UnityEvent<Gradient> { }

    public GradientEvent gradinetEvent = default;
    [SerializeField] GradationBar[] barList = default;

    string defaultData = @"R,G,B,A,P
0,86,255,1,0
64,191,108,1,33
248,253,98,1,66
255,0,0,1,100";

    [SerializeField]
    Gradient gradient = default;

    public void AddBar(GradationBar bar)
    {
        List<GradationBar> list = barList != null ? new List<GradationBar>(barList) : new List<GradationBar>();
        list.Add (bar);
        List<int> ids = new List<int>();
        for(int i = list.Count - 1; i >= 0; i-- ) {
            if (list[i] == null ) { ids.Add (i); }
        }

        for(int i = 0; i < ids.Count;i++ ) {
            list.RemoveAt (ids[i]);
        }

        barList = list.ToArray ();

        ids.Clear ();
        list.Clear ();
    }

    private void Start ()
    {
        // 起動時に一度呼び出す
        Submit ();
    }

    public void Submit()
    {
        try {
            string path = Path.Combine(Application.streamingAssetsPath, "gradation.txt");

            // 参照先ファイルがなかった場合、参照先にファイルを作る
            if ( !File.Exists (path) ) {
                Debug.LogError ("gradation file not Data");
                Debug.LogError ("Create default Data file");

                File.WriteAllText (path, defaultData);
            }


            string text = File.ReadAllText(path);
            string[] lineList = text.Split(System.Environment.NewLine.ToCharArray());
            List<GradationParam> paramList = new List<GradationParam>();
            for ( int i = 1; i < lineList.Length; i++ ) {
                // 先頭文字が数値の場合のみ処理を行う
                if ( lineList[i].Length != 0 && ( lineList[i][0] >= '0' && lineList[i][0] <= '9' ) ) {
                    string[] sp = lineList[i].Split(','); // カンマ区切りで分割
                    // 必要数なければ処理をしない
                    //Debug.Log (sp.Length);
                    if (sp.Length < 5) { continue; }

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

            float t = 1.0f / (float)(paramList.Count - 1);
            GradientColorKey[] colorKeys = new GradientColorKey[paramList.Count];
            for ( int i = 0; i < paramList.Count; i++ ) {
                colorKeys[i] = new GradientColorKey (paramList[i].color, paramList[i].percent / 100f);
            }
            var alphaKeys = new [] {
                new GradientAlphaKey( 1, 0 ),
                new GradientAlphaKey( 1, 1 ),
            };

            // gradationカラーの作成
            gradient.SetKeys (colorKeys, alphaKeys);

            // カラーバーに反映
            foreach ( var gra in barList ) {
                if (gra == null ) { continue; }
                gra.SetColor (paramList);
            }

            // 
            gradinetEvent.Invoke (gradient);
        }
        catch (System.Exception e ) {
            Debug.LogError (e.Message);
        }
        
    }

    public void UpdatePointMax(float f)
    {
        for(int i = 0; i < barList.Length; i++ ) {
            barList[i].SetHigh (f);
        }
    }
}

/// <summary>
/// グラデーションパラメータ
/// </summary>
public class GradationParam
{
    /// <summary> カラー </summary>
    public Color color;
    /// <summary> パーセント ( % ) </summary>
    public int percent;

    public override string ToString ()
    {
        return string.Format ("color({0}, {1}, {2}, {3}) || {4} %",
            color.r,color.g,color.b,color.a,
            percent
            );
    }
}
