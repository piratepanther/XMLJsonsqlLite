using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 用户数据结构
/// </summary>
public class UserVO
{
    public string uid;
    public string userName;
    public string passWord;

    public UserVO(){ }
    public UserVO(string userName, string passWord) 
    {
        this.userName = userName;
        this.passWord = passWord;    
    }
    
    


}
