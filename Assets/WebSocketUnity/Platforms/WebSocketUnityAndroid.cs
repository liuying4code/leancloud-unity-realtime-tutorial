//----------------------------------------------
// WebSocketUnity
// Copyright (c) 2015, Jonathan Pavlou
// All rights reserved
//----------------------------------------------

using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
public class WebSocketUnityAndroid : IWebSocketUnityPlatform
{

    private AndroidJavaObject mWebSocket;

    // Constructor
    // param : url of your server (for example : ws://echo.websocket.org)
    // param : gameObjectName name of the game object who will receive events
    public WebSocketUnityAndroid(string url, string gameObjectName)
    {
        Loom.DispatchToMainThread(() =>
        {
            object[] parameters = new object[2];
            parameters[0] = url;
            parameters[1] = gameObjectName;
            mWebSocket = new AndroidJavaObject("com.jonathanpavlou.WebSocketUnity", parameters);
        }, false, true);
    }

    #region Basic features

    // Open a connection with the specified url
    public void Open()
    {
        Loom.DispatchToMainThread(() =>
        {
            mWebSocket.Call("connect");
        }, false, true);
    }

    // Close the opened connection
    public void Close()
    {

        Loom.DispatchToMainThread(() =>
        {
            mWebSocket.Call("close");
        }, false, true);
    }

    // Check if the connection is opened
    public bool IsOpened()
    {
        return mWebSocket.Call<bool>("isOpen");
    }

    // Send a message through the connection
    // param : message is the sent message
    public void Send(string message)
    {
        Loom.DispatchToMainThread(() =>
        {
            mWebSocket.Call("send", message);
        }, false, true);
    }

    // Send a message through the connection
    // param : data is the sent byte array message
    public void Send(byte[] data)
    {
        Loom.DispatchToMainThread(() =>
        {
            mWebSocket.Call("send", data);
        }, false, true);
    }

    #endregion

}
#else
public class WebSocketUnityAndroid {}
#endif // UNITY_ANDROID
