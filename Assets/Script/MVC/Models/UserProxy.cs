using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserProxy : SQLiteHelper
{
    private void Awake()
    {
        dbName = "UserLoginData.db";


    }
    public void Login(UserVO user)
    {
        OpenDB();
        //查询
        dataReader = db.SelectWhere("User",
            new string[] { "uid" },
            new string[] { "username", "password" },
            new string[] { "=", "=" },
            new string[] { user.userName, user.passWord }
            );
        if (dataReader.HasRows)
        {
            Debug.Log(user.userName+"success");
        }
        else
        {
            Debug.LogError("error");
        }


        CloseDB();
    }



}
