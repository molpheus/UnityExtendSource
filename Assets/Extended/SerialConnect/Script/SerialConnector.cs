/**
* シリアル接続の基本クラス
* 受信処理の実装は使用する機器ごとに違うので
* このクラスを拡張して実装する
* 
* Yoshida@DigiFie
* https://www.digifie.jp/blog/archives/1580
**/
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using UnityEngine;

public class SerialConnector : MonoBehaviour
{

    protected SerialPort _serialPort;

    // ボート名などはエディタから設定できる
    /// <summary> シリアルポート名 </summary>
    public string portName = "COM0";
    /// <summary> 通信速度指定 </summary>
    public int baudRate = 38400;
    /// <summary> スレッドスリープ（ミリ秒） </summary>
    public int threadSleepTime = 1000;

    // シリアル設定用パラメータ
    /// <summary> パリティビット </summary>
    public Parity _parity;
    /// <summary> データビット </summary>
    public int _databits;
    /// <summary> ストップビット </summary>
    public StopBits _stopbits;
    /// <summary>  </summary>
    public int _readTimeout;
    /// <summary>  </summary>
    public int _writeTimeout;

    // スレッド
    /// <summary>  </summary>
    protected Thread _thread;
    /// <summary>  </summary>
    protected bool _isRunning;

    // signal
    protected bool _dtrEnable = false;
    protected bool _rtsEnable = false;

    // handshake
    protected Handshake _handShake = Handshake.None;

    // 終了処理
    protected void OnDestroy ()
    {
        close ();
    }


    // シリアルポートを開いて接続
    protected bool open ()
    {
        try {
            string name = portName;
            // serialport 構文
            string noCOM = portName.Replace("COM", "");
            int number = int.Parse(noCOM);
            if (number > 9) {
                // 二桁以上のCOMの頭につける必要がある
                name = string.Format ("\\\\.\\COM{0}", number);
            }
            else {
                name = string.Format ("COM{0}", number);
            }

            //Debug.Log ("name : " + name);


            // ポート名, ボーレート, パリティチェック, データビット長, ストップビット長,
            // 読み取り時タイムアウト, 書き込み時タイムアウトを設定してポートを開く
            _serialPort = new SerialPort (name) {
                //PortName = name,
                BaudRate = baudRate,
                Parity = _parity,
                DataBits = _databits,
                StopBits = _stopbits,
                ReadTimeout = _readTimeout,
                WriteTimeout = _writeTimeout,

                // HandShake
                Handshake = _handShake,

                // DTR (Date Terminal Ready) シグナルの有効化
                DtrEnable = _dtrEnable,

                // RTS (Request To Send) シグナルの有効化
                RtsEnable = _rtsEnable
            };

            //Debug.Log ("Port Open");
            // 接続する
            _serialPort.Open ();
        }
        catch ( System.Exception e ) {
            Debug.LogWarning (e.Message);
            Debug.LogWarning ("stacktrace : " + e.StackTrace);
        }

        return _serialPort != null ? _serialPort.IsOpen : false;
    }

    // スレッドを停止してシリアルポートを閉じる
    protected void close ()
    {
        _isRunning = false;

        if ( _thread != null && _thread.IsAlive ) {
            _thread.Abort ();
        }

        if ( _serialPort != null && _serialPort.IsOpen ) {
            _serialPort.Close ();
            _serialPort.Dispose ();
        }
    }

    //protected List<byte> buffer = new List<byte>();
    //public string ReadBufferStrings()
    //{
    //    string str = System.Text.Encoding.ASCII.GetString (buffer.ToArray());
    //    str = str.Replace ("\t", "\n");
    //    return str;
    //}

    //public void ClearBuffer()
    //{
    //    buffer.Clear ();
    //}

    // スレッドラン
    protected void run ()
    {
        while ( _isRunning && _serialPort != null && _serialPort.IsOpen ) {

            // 受信バッファをクリア
            //try {
            //    _serialPort.DiscardInBuffer ();
            //}
            //catch ( System.Exception e ) {
            //    Debug.LogWarning (e.Message);
            //}

            //if (_serialPort.BytesToRead != 0) {
            //    byte[] buf = new  byte[_serialPort.BytesToRead];
            //    _serialPort.Read (buf,0, _serialPort.BytesToRead);
            //    buffer.AddRange (buf);
            //    //Debug.Log (System.Text.Encoding.ASCII.GetString(buffer));
            //    _serialPort.DiscardInBuffer ();
            //}

            // 指定秒数待機
            Thread.Sleep (threadSleepTime);

            // 読み取り
            serialRead ();
        }
    }

    // シリアルポート読み取り処理（シリアル受信処理）
    public virtual void serialRead ()
    {
        // 実装はサブクラスでオーバーライドする
        // 受信バッファの削除はベースクラスで行わず、オーバーライド先で処理後に行うこと
    }

    public void Send(string message)
    {
        _serialPort.WriteLine (message);
    }
}