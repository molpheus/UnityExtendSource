using UnityEngine;

namespace com.molmolgames.U_Ex
{
    public static class TransformExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static RectTransform rectTransform (this Transform trans)
        {
            return (RectTransform)trans;
        }

        #region Position
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetPositionX (this Transform trans, float value)
        {
            trans.SetPosition (value, trans.position.y, trans.position.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetPositionY (this Transform trans, float value)
        {
            trans.SetPosition (trans.position.x, value, trans.position.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetPositionZ (this Transform trans, float value)
        {
            trans.SetPosition (trans.position.x, trans.position.y, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void SetPosition (this Transform trans, float x, float y, float z)
        {
            trans.position = new Vector3 (x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddPositionX (this Transform trans, float value)
        {
            trans.AddPosition (value, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddPositionY (this Transform trans, float value)
        {
            trans.AddPosition (0, value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddPositionZ (this Transform trans, float value)
        {
            trans.AddPosition (0, 0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddPosition (this Transform trans, float x, float y, float z)
        {
            trans.position = new Vector3 (trans.position.x + x, trans.position.y + y, trans.position.z + z);
        }
        #endregion

        #region LocalPosition
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalPositionX (this Transform trans, float value)
        {
            trans.SetLocalPosition (value, trans.localPosition.y, trans.localPosition.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalPositionY (this Transform trans, float value)
        {
            trans.SetLocalPosition (trans.localPosition.x, value, trans.localPosition.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalPositionZ (this Transform trans, float value)
        {
            trans.SetLocalPosition (trans.localPosition.x, trans.localPosition.y, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void SetLocalPosition (this Transform trans, float x, float y, float z)
        {
            trans.localPosition = new Vector3 (x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalPositionX (this Transform trans, float value)
        {
            trans.AddLocalPosition (value, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalPositionY (this Transform trans, float value)
        {
            trans.AddLocalPosition (0, value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalPositionZ (this Transform trans, float value)
        {
            trans.AddLocalPosition (0, 0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddLocalPosition (this Transform trans, float x, float y, float z)
        {
            trans.position = new Vector3 (trans.localPosition.x + x, trans.localPosition.y + y, trans.localPosition.z + z);
        }
        #endregion

        #region LocalScale
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalScaleX (this Transform trans, float value)
        {
            trans.SetLocalScale (value, trans.localScale.y, trans.localScale.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalScaleY (this Transform trans, float value)
        {
            trans.SetLocalScale (trans.localScale.x, value, trans.localScale.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalScaleZ (this Transform trans, float value)
        {
            trans.SetLocalScale (trans.localScale.x, trans.localScale.y, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void SetLocalScale (this Transform trans, float x, float y, float z)
        {
            trans.localScale = new Vector3 (x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalScaleX (this Transform trans, float value)
        {
            trans.AddLocalScale (value, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalScaleY (this Transform trans, float value)
        {
            trans.AddLocalScale (0, value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalScaleZ (this Transform trans, float value)
        {
            trans.AddLocalScale (0, 0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddLocalScale (this Transform trans, float x, float y, float z)
        {
            trans.localScale = new Vector3 (x + trans.localScale.x, y + trans.localScale.y, z + trans.localScale.z);
        }
        #endregion

        #region EulerAngles
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetEulerAnglesX (this Transform trans, float value)
        {
            trans.SetEulerAngles (value, trans.eulerAngles.y, trans.eulerAngles.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetEulerAnglesY (this Transform trans, float value)
        {
            trans.SetEulerAngles (trans.eulerAngles.x, value, trans.eulerAngles.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetEulerAnglesZ (this Transform trans, float value)
        {
            trans.SetEulerAngles (trans.eulerAngles.x, trans.eulerAngles.y, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void SetEulerAngles (this Transform trans, float x, float y, float z)
        {
            trans.eulerAngles = new Vector3 (x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddEulerAnglesX (this Transform trans, float value)
        {
            trans.AddEulerAngles (value, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddEulerAnglesY (this Transform trans, float value)
        {
            trans.AddEulerAngles (0, value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddEulerAnglesZ (this Transform trans, float value)
        {
            trans.AddEulerAngles (0, 0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddEulerAngles (this Transform trans, float x, float y, float z)
        {
            trans.eulerAngles = new Vector3 (x + trans.eulerAngles.x, y + trans.eulerAngles.y, z + trans.eulerAngles.z);
        }
        #endregion

        #region LocalEulerAngles
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalEulerAnglesX (this Transform trans, float value)
        {
            trans.SetLocalEulerAngles (value, trans.localEulerAngles.y, trans.localEulerAngles.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalEulerAnglesY (this Transform trans, float value)
        {
            trans.SetLocalEulerAngles (trans.localEulerAngles.x, value, trans.localEulerAngles.z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void SetLocalEulerAnglesZ (this Transform trans, float value)
        {
            trans.SetLocalEulerAngles (trans.localEulerAngles.x, trans.localEulerAngles.y, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void SetLocalEulerAngles (this Transform trans, float x, float y, float z)
        {
            trans.localEulerAngles = new Vector3 (x, y, z);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalEulerAnglesX (this Transform trans, float value)
        {
            trans.AddLocalEulerAngles (value, 0, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalEulerAnglesY (this Transform trans, float value)
        {
            trans.AddLocalEulerAngles (0, value, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static void AddLocalEulerAnglesZ (this Transform trans, float value)
        {
            trans.AddLocalEulerAngles (0, 0, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddLocalEulerAngles (this Transform trans, float x, float y, float z)
        {
            trans.localEulerAngles = new Vector3 (x + trans.localEulerAngles.x, y + trans.localEulerAngles.y, z + trans.localEulerAngles.z);
        }
        #endregion
    }
}