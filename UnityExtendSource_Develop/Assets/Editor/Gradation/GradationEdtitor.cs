using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.molmolgames.U_Ex.Editor
{
    public class GradetionEditor : UnityEditor.Editor
    {
        [UnityEditor.MenuItem ("GameObject/UI/Gradation/GradationBar", false, 0)]
        public static void CreateBar ()
        {
            var gradation = GameObject.FindObjectOfType<Gradation> ();
            if ( gradation == null ) {
                GameObject gradationObj = new GameObject("GradationSettings");
                gradation = gradationObj.AddComponent<Gradation> ();
            }

            if ( UnityEditor.Selection.gameObjects.Length != 0 ) {
                for ( int i = 0; i < UnityEditor.Selection.gameObjects.Length; i++ ) {

                    GameObject bar = new GameObject("gradationBar");
                    bar.transform.position = UnityEditor.Selection.gameObjects[i].transform.position;
                    bar.transform.SetParent (UnityEditor.Selection.gameObjects[i].transform);
                    GradationBar gradationBar = bar.AddComponent<GradationBar>();
                    bar.AddComponent<RectTransform> ();
                    ( (RectTransform)gradationBar.transform ).sizeDelta = new Vector2 (40, 160);

                    GameObject topText = new GameObject("TopText");
                    topText.transform.SetParent (bar.transform);
                    var textTop = topText.AddComponent<Text> ();
                    textTop.text = "0";
                    textTop.resizeTextForBestFit = true;
                    SetRectTransform ((RectTransform)topText.transform,
                        new Vector2 (0f, 1),
                        new Vector2 (1f, 1),
                        new Vector2 (0, 15),
                        new Vector2 (0.5f, 0f),
                        Vector2.zero
                    );

                    GameObject bottomText = new GameObject("BottomText");
                    bottomText.transform.SetParent (bar.transform);
                    var textBottom = bottomText.AddComponent<Text> ();
                    textBottom.text = "0";
                    textBottom.resizeTextForBestFit = true;
                    SetRectTransform ((RectTransform)bottomText.transform,
                        new Vector2 (0f, 0),
                        new Vector2 (1f, 0),
                        new Vector2 (0, 15),
                        new Vector2 (0.5f, 1f),
                        Vector2.zero
                    );

                    GameObject area = new GameObject("Area");
                    area.transform.SetParent (bar.transform);
                    area.AddComponent<RectTransform> ();
                    SetRectTransform ((RectTransform)area.transform,
                        new Vector2 (0f, 0),
                        new Vector2 (1f, 1),
                        Vector2.zero,
                        new Vector2 (0.5f, 0.5f),
                        Vector2.zero
                    );
                    var areaVertical = area.AddComponent<VerticalLayoutGroup> ();
                    areaVertical.childAlignment = TextAnchor.LowerCenter;
                    areaVertical.childForceExpandHeight = false;
                    areaVertical.childForceExpandWidth = false;

                    GameObject chip = new GameObject("items");
                    chip.transform.SetParent (area.transform);
                    chip.AddComponent<Image> ();
                    chip.AddComponent<GradationMesh> ();
                    var graPer = chip.AddComponent<GradationPercent> ();
                    ( (RectTransform)chip.transform ).sizeDelta = new Vector2 (40, 160);

                    GameObject percentBase = new GameObject("base");
                    percentBase.transform.SetParent (chip.transform);
                    percentBase.AddComponent<Image> ();
                    SetRectTransform ((RectTransform)percentBase.transform,
                        new Vector2 (1f, 0),
                        new Vector2 (1f, 0),
                        new Vector2 (30, 15),
                        new Vector2 (0f, 0.5f),
                        Vector2.zero
                    );

                    GameObject percent = new GameObject("percent");
                    percent.transform.SetParent (percentBase.transform);
                    var perText = percent.AddComponent<Text> ();
                    perText.text = "text";
                    perText.resizeTextForBestFit = true;
                    SetRectTransform ((RectTransform)percent.transform,
                        new Vector2 (0f, 0),
                        new Vector2 (1f, 1),
                        Vector2.zero,
                        new Vector2 (0.5f, 0.5f),
                        Vector2.zero
                    );

                    chip.SetActive (false);
                    percentBase.SetActive (false);

                    graPer.SetTextObject (perText);

                    gradationBar.SetBase ((RectTransform)area.transform, chip);
                    gradationBar.SetTextObject (textTop, textBottom);

                    gradation.AddBar (gradationBar);
                }
            }
        }

        static void SetRectTransform (RectTransform trans, Vector2 anchorMin, Vector2 anchorMax, Vector2 sizeDelta, Vector2 pivot, Vector2 anchoredPosition)
        {
            trans.anchorMin = anchorMin;
            trans.anchorMax = anchorMax;
            trans.sizeDelta = sizeDelta;
            trans.pivot = pivot;
            trans.anchoredPosition = anchoredPosition;
        }
    }
}