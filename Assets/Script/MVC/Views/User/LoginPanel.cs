using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    private InputField UserNameInput;
    private InputField pwdInput;
    private Button LoginButton;
    private Button SignButton;
    
    //找组件
    private void Awake()
    {
        UserNameInput = transform.Find("UserNameInput").GetComponent<InputField>();
        pwdInput = transform.Find("pwdInput").GetComponent<InputField>();
        LoginButton = transform.Find("LoginButton").GetComponent<Button>();
        SignButton = transform.Find("SignButton").GetComponent<Button>();
        LoginButton.onClick.AddListener(Login);


    }

    
    //监听事件
    private void Login()
    {
        //检查是否为空
        if (UserNameInput.text == "" || pwdInput.text == "")
        {
            Debug.Log("不能为空");
            return;
        }


        //检查非法字符



        //获取用户名密码



        //UserProxy login
        UserProxy userProxy = GetComponent<UserProxy>();

        UserVO user=new UserVO(UserNameInput.text,pwdInput.text);

        userProxy.Login(user);

    }




    //login





}
