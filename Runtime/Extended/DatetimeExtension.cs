using System;
using System.Globalization;

namespace MolmolgamesEngine.U_Ex
{
    public static class DatetimeExtension
    {
        /// <summary> ロケーション情報. </summary>
        private static CultureInfo ci = new CultureInfo("ja-JP");

        private static readonly int FiscalYearStartingMonth = 4;

        /// <summary>
        /// ロケーション情報を変更する
        /// </summary>
        /// <param name="info"></param>
        public static void ChangeCultureInfo(CultureInfo info)
        {
            ci = info;
        }

        /// <summary>
        /// 該当年月の日数を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>DateTime</returns>
        public static int DaysInMonth (this DateTime dt)
        {
            return DateTime.DaysInMonth (dt.Year, dt.Month);
        }

        /// <summary>
        /// 月初日を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>Datetime</returns>
        public static DateTime BeginOfMonth (this DateTime dt)
        {
            return dt.AddDays (( dt.Day - 1 ) * -1);
        }

        /// <summary>
        /// 月末日を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>DateTime</returns>
        public static DateTime EndOfMonth (this DateTime dt)
        {
            return new DateTime (dt.Year, dt.Month, DaysInMonth (dt));
        }

        /// <summary>
        /// 時刻を落として日付のみにする
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>DateTime</returns>
        public static DateTime StripTime (this DateTime dt)
        {
            return new DateTime (dt.Year, dt.Month, dt.Day);
        }

        /// <summary>
        /// 日付を落として時刻のみにする
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="base_date">DateTime* : 基準日</param>
        /// <returns>DateTime</returns>
        public static DateTime StripDate (this DateTime dt, DateTime? base_date = null)
        {
            base_date = base_date ?? DateTime.MinValue;
            return new DateTime (base_date.Value.Year, base_date.Value.Month, base_date.Value.Day, dt.Hour, dt.Minute, dt.Second);
        }

        /// <summary>
        /// 該当日付の年度を返す
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="startingMonth">int? : 年度の開始月</param>
        /// <returns>int</returns>
        public static int FiscalYear (this DateTime dt, int? startingMonth = null)
        {
            return ( dt.Month >= ( startingMonth ?? FiscalYearStartingMonth ) ) ? dt.Year : dt.Year - 1;
        }

        /// <summary>
        /// yyyy/MM/dd HH:mm:ss 形式の文字列に変換して返します
        /// </summary>
        public static string ToPattern (this DateTime self)
        {
            return self.ToString ("yyyy/MM/dd HH:mm:ss", ci);
        }

        /// <summary>
        /// yyyy/MM/dd 形式の文字列に変換して返します
        /// </summary>
        public static string ToShortDatePattern (this DateTime self)
        {
            return self.ToString ("yyyy/MM/dd", ci);
        }

        /// <summary>
        /// yyyy年M月d日 形式の文字列に変換して返します
        /// </summary>
        public static string ToLongDatePattern (this DateTime self)
        {
            return self.ToString ("yyyy年M月d日", ci);
        }

        /// <summary>
        /// yyyy年M月d日 HH:mm:ss 形式の文字列に変換して返します
        /// </summary>
        public static string ToFullDateTimePattern (this DateTime self)
        {
            return self.ToString ("yyyy年M月d日 HH:mm:ss", ci);
        }

        /// <summary>
        /// HH:mm 形式の文字列に変換して返します
        /// </summary>
        public static string ToShortTimePattern (this DateTime self)
        {
            return self.ToString ("HH:mm", ci);
        }

        /// <summary>
        /// HH:mm:ss 形式の文字列に変換して返します
        /// </summary>
        public static string ToLongTimePattern (this DateTime self)
        {
            return self.ToString ("HH:mm:ss", ci);
        }

        /// <summary>
        /// M月　dd日（ddd）形式の文字列に変換して返します
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToShotDatetimeOrigin (this DateTime self)
        {
            return self.ToString ("M月  dd日（ddd）", ci);
        }
    }
}