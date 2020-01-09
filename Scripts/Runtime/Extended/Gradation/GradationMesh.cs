using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.molmolgames.U_Ex
{
    /// <summary>
    /// Meshの頂点にカラー情報を設定する
    /// 想定先メッシュは、UnityEngine.UI.Image
    /// </summary>
    public class GradationMesh : BaseMeshEffect
    {
        /**
         * UnityEngine.UI.Imageで各頂点の番号について確認した所
         * b c
         * a d
         * */
        /// <summary> 左下 </summary>
        public Color a = Color.red;
        /// <summary> 左上 </summary>
        public Color b = Color.blue;
        /// <summary> 右上 </summary>
        public Color c = Color.green;
        /// <summary> 右下 </summary>
        public Color d = Color.black;
        public override void ModifyMesh (VertexHelper vh)
        {
            if ( !IsActive () ) return;
            UIVertex v = new UIVertex();
            int idx = 0;
            for ( int i = 0; i < vh.currentVertCount; i++ ) {
                vh.PopulateUIVertex (ref v, i);
                switch ( idx ) {
                    case 0: v.color = a; break;
                    case 1: v.color = b; break;
                    case 2: v.color = c; break;
                    case 3: v.color = d; break;
                }
                if ( ++idx >= 4 ) { idx = 0; }
                vh.SetUIVertex (v, i);
            }
        }

        /// <summary>
        /// 頂点ごとのカラー変更（2色グラデーション）
        /// </summary>
        /// <param name="top"> 上辺 </param>
        /// <param name="bottom"> 下辺 </param>
        public void SetColorUpDown (Color top, Color bottom)
        {
            a = d = bottom;
            b = c = top;
        }

        /// <summary>
        /// 頂点ごとのカラー変更（2色グラデーション）
        /// </summary>
        /// <param name="left"> 左辺 </param>
        /// <param name="right"> 右辺 </param>
        public void SetColorLeftRight (Color left, Color right)
        {
            a = b = left;
            c = d = right;
        }

        /// <summary>
        /// 頂点ごとのカラー変更（4色グラデーション）
        /// </summary>
        /// <param name="leftBottom"> 左下頂点カラー </param>
        /// <param name="leftTop"> 左上頂点カラー </param>
        /// <param name="rightTop"> 右上頂点カラー </param>
        /// <param name="rightBottom"> 右下頂点カラー </param>
        public void SetColor (Color leftBottom, Color leftTop, Color rightTop, Color rightBottom)
        {
            a = leftBottom;
            b = leftTop;
            c = rightTop;
            d = rightBottom;
        }
    }
}