using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLTest : MonoBehaviour
{

    private string fileName = "test.xml";
    private string filePath
    {
        get
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return Application.persistentDataPath + "/" + fileName;
            }
            
            
            return Application.dataPath + "/" + fileName;



        }
    }
    
    
    //创建
    private void CreatXML()
    {
        Debug.Log("creatXML");
        //生成xmlDoc实例
        XmlDocument xmlDoc = new XmlDocument();

        //Head头部声明
        XmlDeclaration Header = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
        xmlDoc.AppendChild(Header);

        //根节点
        XmlElement root = xmlDoc.CreateElement("root_Element");
        xmlDoc.AppendChild(root);

        //一级节点、ID、name
        XmlElement root1 = xmlDoc.CreateElement("CharactorData");
        root1.SetAttribute("id", "1000"); root1.SetAttribute("name", "fashi");
        root.AppendChild(root1);

        //二级节点、保存
        XmlElement root21 = xmlDoc.CreateElement("JobID");
        root21.InnerText = "2";
        root1.AppendChild(root21);
        XmlElement root22 = xmlDoc.CreateElement("JobMode");
        root22.InnerText = "Wizard";
        root1.AppendChild(root22);
        XmlElement root23 = xmlDoc.CreateElement("InitForce");
        root23.InnerText = "100";
        root1.AppendChild(root23);

        //查看
        Debug.Log(xmlDoc.InnerXml);

        //保存
        xmlDoc.Save(filePath);


    }

    //删除


    //增加

    private void AddXML()
    {
        Debug.Log("AddXML()");
        
        //检测文件是否存在
        if(!File.Exists(filePath))
        {
            Debug.LogError("no file");
            return;
        }
        
        //xmlDoc实例
        XmlDocument xmlDoc = new XmlDocument();

        //加载XML文件
        xmlDoc.Load(filePath); Debug.Log(xmlDoc.InnerXml);

        //获取根节点
        XmlNode root = xmlDoc.SelectSingleNode("root_Element");

        //添加一级节点
        XmlElement root1 = xmlDoc.CreateElement("CharactorData");
        root1.SetAttribute("id", "1000"); root1.SetAttribute("name", "fashi");
        root.AppendChild(root1);

        //二级节点、保存
        XmlElement root21 = xmlDoc.CreateElement("JobID");
        root21.InnerText = "2";
        root1.AppendChild(root21);
        XmlElement root22 = xmlDoc.CreateElement("JobMode");
        root22.InnerText = "Wizard";
        root1.AppendChild(root22);
        XmlElement root23 = xmlDoc.CreateElement("InitForce");
        root23.InnerText = "100";
        root1.AppendChild(root23);
        

        //保存文件



    }




    //修改


    //查询


//     private void AddElement()
//     {
// 
// 
// 
//     }



    private void OnGUI()
    {
        if (GUILayout.Button("创建XML"))
        {
            CreatXML();  
        }

        if (GUILayout.Button("添加XML"))
        {
            AddXML();
        }


        GUILayout.Label("platform:" + Application.platform);
        GUILayout.Label("datapath:" + Application.dataPath);//一般读写，非移动
        GUILayout.Label("presistendatapath:" + Application.persistentDataPath);//Android读写（www下载file.wrie）
        GUILayout.Label("streamingAssetsPath:" + Application.streamingAssetsPath);//打包时带的文件，不允许变动

    }




}
