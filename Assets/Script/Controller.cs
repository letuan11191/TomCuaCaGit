using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sfs2X;
using Sfs2X.Core;
using UnityEngine.SceneManagement;
using Sfs2X.Entities;
using System;
using Sfs2X.Entities.Variables;
using Sfs2X.Requests;
using UnityEngine.UI;
using Sfs2X.Entities.Data;

public class Controller : MonoBehaviour
{

    public static Controller Ctr
    {
        get
        {
            return ctr;
        }
    }
    private static Controller ctr;
    public static string DiceName { get; set; }
    public static string ChooseDice { get; set; }
    public static int Score { get; set; }
    public GameObject cv;
    public Text ScoreTxt;
    public Text UserName;

    //Manager//
    private SmartFox sfs;

    void Awake()
    {
        ctr = this;
        Application.runInBackground = true;

    }
    // Use this for initialization
    void Start()
    {        
        if (SmartFoxConnection.CheckConnection())
        {
            sfs = SmartFoxConnection.Connection;
            
            sfs.AddEventListener(SFSEvent.USER_VARIABLES_UPDATE, OnUserVariablesUpdate);
            sfs.AddEventListener(SFSEvent.CONNECTION_LOST, OnConnectionLost);
            sfs.AddEventListener(SFSEvent.USER_ENTER_ROOM, OnUserEnterRoom);
            sfs.AddEventListener(SFSEvent.USER_ENTER_ROOM, OnUserExitRoom);
            Score = 100;
            cv.SetActive(false);
            Time.timeScale = 0;            
            UserName.text = "User Name: " + Connection.username;
        }
        else
        {
            SceneManager.LoadScene("Login");
        }
        sfs.AddEventListener(SFSEvent.EXTENSION_RESPONSE, OnExtensionResponse);

    }

    private void OnExtensionResponse(BaseEvent evt)
    {
        Debug.Log("OnExtensionResponse");
        try
        {
            string cmd = (string)evt.Params["cmd"];
            ISFSObject dt = (SFSObject)evt.Params["params"];
            if(cmd == "login")
            {

            }
            else if(cmd == "Thongbaoserver")
            {
                string str = dt.GetUtfString("mess");
                Debug.Log(str);
            }
            else
            {
                Debug.Log("no mess");
            }
        }catch(Exception e)
        {
            Debug.Log("Exception e: " + e);
        }
    }

    private void OnUserVariablesUpdate(BaseEvent evt)
    {
        throw new NotImplementedException();
    }

    private void OnConnectionLost(BaseEvent evt)
    {
        throw new NotImplementedException();
    }

    private void OnUserEnterRoom(BaseEvent evt)
    {
        throw new NotImplementedException();
    }

    private void OnUserExitRoom(BaseEvent evt)
    {
        throw new NotImplementedException();
    }

    public void SendToServer()
    {
        Debug.Log("SendToServer");
        ISFSObject data = new SFSObject();
        data.PutUtfString("logDebug", "Data gui len tu client");
        data.PutLong("gold", Score);
        //data.PutUtfString("Choose", ChooseDice);
        //data.PutUtfString("result", DiceName);

        ExtensionRequest request = new ExtensionRequest("DebugClient", data);
        sfs.Send(request);

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(DiceName);
        if (ChooseDice == null)
        {
            Time.timeScale = 0;
        }
        else
        {
            if (DiceName != null)
            {
                //cv.SetActive(true);
                cv.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(DiceName);
                Time.timeScale = 0;
                if (DiceName == ChooseDice)
                {
                    Score += 10;
                }
                else
                {
                    Score -= 10;
                }
            }
            
        }
        ScoreTxt.text = Score.ToString();

    }
}
