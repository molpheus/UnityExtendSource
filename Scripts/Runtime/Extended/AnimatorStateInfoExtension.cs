using UnityEngine;

namespace com.molmolgames.U_Ex
{
    /// <summary>
    /// AnimatorStateInfo の Extension
    /// </summary>
    public static class AnimatorStateInfoExtension
    {
        /// <summary>
        /// 現在の経過時間を取得する
        /// </summary>
        public static float time (this AnimatorStateInfo info)
        {
            // info.length : ステートの現在の長さ
            // info.normalizedTime : ステートの正規化された時間( 0 ~ 1 )
            return Mathf.Lerp (0, info.length, info.normalizedTime);
        }
    }
}