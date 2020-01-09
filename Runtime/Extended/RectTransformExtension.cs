using UnityEngine;

namespace MolmolgamesEngine.U_Ex
{
    public static class RectTransformExtension
    {
        #region anchoredPosition
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchoredPositionX (this RectTransform trans, float value)
        {
            trans.SetAnchoredPosition (value, trans.anchoredPosition.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchoredPositionY (this RectTransform trans, float value)
        {
            trans.SetAnchoredPosition (trans.anchoredPosition.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetAnchoredPosition (this RectTransform trans, float x, float y)
        {
            trans.anchoredPosition = new Vector2 (x, y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddAnchoredPositionX (this RectTransform trans, float value)
        {
            trans.AddAnchoredPosition (value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddAnchoredPositionY (this RectTransform trans, float value)
        {
            trans.AddAnchoredPosition (0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AddAnchoredPosition (this RectTransform trans, float x, float y)
        {
            trans.anchoredPosition = new Vector2 (x + trans.anchoredPosition.x, y + trans.anchoredPosition.y);
        }
        #endregion

        #region anchoredPosition3D
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchoredPosition3DX (this RectTransform trans, float value)
        {
            trans.SetAnchoredPosition3D (value, trans.anchoredPosition3D.y, trans.anchoredPosition3D.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchoredPosition3DY (this RectTransform trans, float value)
        {
            trans.SetAnchoredPosition3D (trans.anchoredPosition3D.x, value, trans.anchoredPosition3D.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchoredPosition3DZ (this RectTransform trans, float value)
        {
            trans.SetAnchoredPosition3D (trans.anchoredPosition3D.x, trans.anchoredPosition3D.y, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetAnchoredPosition3D (this RectTransform trans, float x, float y, float z)
        {
            trans.anchoredPosition3D = new Vector3 (x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddAnchoredPosition3DX (this RectTransform trans, float value)
        {
            trans.AddAnchoredPosition3D (value, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddAnchoredPosition3DY (this RectTransform trans, float value)
        {
            trans.AddAnchoredPosition3D (0, value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddAnchoredPosition3DZ (this RectTransform trans, float value)
        {
            trans.SetAnchoredPosition3D (0, 0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AddAnchoredPosition3D (this RectTransform trans, float x, float y, float z)
        {
            trans.anchoredPosition3D = new Vector3 (x + trans.anchoredPosition.x, y + trans.anchoredPosition.y, z + trans.anchoredPosition3D.z);
        }
        #endregion

        #region anchorMax
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchorMaxX (this RectTransform trans, float value)
        {
            trans.SetAnchorMax (value, trans.anchorMax.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchorMaxY (this RectTransform trans, float value)
        {
            trans.SetAnchorMax (trans.anchorMax.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetAnchorMax (this RectTransform trans, float x, float y)
        {
            trans.anchorMax = new Vector2 (x, y);
        }
        #endregion

        #region anchorMin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchorMinX (this RectTransform trans, float value)
        {
            trans.SetAnchorMin (value, trans.anchorMin.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetAnchorMinY (this RectTransform trans, float value)
        {
            trans.SetAnchorMin (trans.anchorMin.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetAnchorMin (this RectTransform trans, float x, float y)
        {
            trans.anchorMin = new Vector2 (x, y);
        }
        #endregion

        #region anchor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"> Min(rect.xMin, rect.yMin) Max(rect.xMax, rect.yMax)  </param>
        public static void SetAnchor (this RectTransform trans, Rect rect)
        {
            trans.SetAnchorMin (rect.xMin, rect.yMin);
            trans.SetAnchorMax (rect.xMax, rect.yMax);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMin"> min.x </param>
        /// <param name="yMin"> min.y </param>
        /// <param name="xMax"> max.x </param>
        /// <param name="yMax"> max.y </param>
        public static void SetAnchor (this RectTransform trans, float xMin, float yMin, float xMax, float yMax)
        {
            trans.SetAnchorMin (xMin, yMin);
            trans.SetAnchorMax (xMax, yMax);
        }
        #endregion

        #region offsetMax
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetOffsetMaxX (this RectTransform trans, float value)
        {
            trans.SetOffsetMax (value, trans.offsetMax.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetOffsetMaxY (this RectTransform trans, float value)
        {
            trans.SetOffsetMax (trans.offsetMax.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="value"></param>
        public static void SetOffsetMax (this RectTransform trans, float x, float y)
        {
            trans.offsetMax = new Vector2 (x, y);
        }
        #endregion

        #region offsetMin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetOffsetMinX (this RectTransform trans, float value)
        {
            trans.SetOffsetMin (value, trans.offsetMin.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetOffsetMinY (this RectTransform trans, float value)
        {
            trans.SetOffsetMin (trans.offsetMin.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="value"></param>
        public static void SetOffsetMin (this RectTransform trans, float x, float y)
        {
            trans.offsetMin = new Vector2 (x, y);
        }
        #endregion

        #region offset
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"> Min(rect.xMin, rect.yMin) Max(rect.xMax, rect.yMax)  </param>
        public static void SetOffset (this RectTransform trans, Rect rect)
        {
            trans.SetOffsetMin (rect.xMin, rect.yMin);
            trans.SetOffsetMax (rect.xMax, rect.yMax);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xMin"> min.x </param>
        /// <param name="yMin"> min.y </param>
        /// <param name="xMax"> max.x </param>
        /// <param name="yMax"> max.y </param>
        public static void SetOffset (this RectTransform trans, float xMin, float yMin, float xMax, float yMax)
        {
            trans.SetOffsetMin (xMin, yMin);
            trans.SetOffsetMax (xMax, yMax);
        }
        #endregion

        #region pivot
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetPivotX (this RectTransform trans, float value)
        {
            trans.SetPivot (value, trans.pivot.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetPivotY (this RectTransform trans, float value)
        {
            trans.SetPivot (trans.pivot.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetPivot (this RectTransform trans, float x, float y)
        {
            trans.pivot = new Vector2 (x, y);
        }
        #endregion

        #region sizeDelta
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetSizeDeltaX (this RectTransform trans, float value)
        {
            trans.SetSizeDelta (value, trans.sizeDelta.y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetSizeDeltaY (this RectTransform trans, float value)
        {
            trans.SetSizeDelta (trans.sizeDelta.x, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetSizeDelta (this RectTransform trans, float x, float y)
        {
            trans.sizeDelta = new Vector2 (x, y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddSizeDeltaX (this RectTransform trans, float value)
        {
            trans.AddSizeDelta (value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddSizeDeltaY (this RectTransform trans, float value)
        {
            trans.AddSizeDelta (0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AddSizeDelta (this RectTransform trans, float x, float y)
        {
            trans.sizeDelta = new Vector2 (x + trans.sizeDelta.x, y + trans.sizeDelta.y);
        }
        #endregion
    }
}