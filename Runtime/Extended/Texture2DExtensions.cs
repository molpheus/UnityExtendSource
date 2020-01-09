using UnityEngine;

namespace MolmolgamesEngine.U_Ex
{
    /// <summary>
    /// 
    /// </summary>
    public static class Texture2DExtensions
    {
        /// <summary>
        /// テクスチャのリサイズを行う
        /// </summary>
        /// <param name="width"> 横 </param>
        /// <param name="height"> 高さ </param>
        /// <returns></returns>
        public static Texture2D GetResized (this Texture2D texture, int width, int height)
        {
            // リサイズ後のサイズを持つRenderTextureを作成して書き込む
            var rt = RenderTexture.GetTemporary(width, height);
            Graphics.Blit (texture, rt);

            // リサイズ後のサイズを持つTexture2Dを作成してRenderTextureから書き込む
            var preRT = RenderTexture.active;
            RenderTexture.active = rt;
            var ret = new Texture2D(width, height);
            ret.ReadPixels (new Rect (0, 0, width, height), 0, 0);
            ret.Apply ();
            RenderTexture.active = preRT;

            RenderTexture.ReleaseTemporary (rt);
            return ret;
        }
    }
}