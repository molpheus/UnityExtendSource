using UnityEngine;

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
