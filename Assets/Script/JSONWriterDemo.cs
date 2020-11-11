using UnityEngine;
using System.Collections;
using LitJson;

public class JSONWriterDemo : MonoBehaviour
{
    private void CreatJSON()
    {
        //{"name":"张三","lv":1,"job":"法师","exp":1.1}
        JsonWriter json = new JsonWriter();
        json.WriteObjectStart();//{
//         json.WritePropertyName("name");//{"name":
//         json.Write("张三");//{"name":"张三"

        AddProperty(json, "name", "张三");



        json.WriteObjectEnd();//{"name":"张三"}
        Debug.Log(json.ToString());

    }

    private void AddProperty(JsonWriter json, string key,string value)
    {
        json.WritePropertyName(key);//{"name":
        json.Write(value);//{"name":"张三"
    }


    private void CreatCompositeJSON()
    {
        //jsonWriter实例
        JsonWriter json = new JsonWriter();
        //开始写对象
        json.WriteObjectStart();

            //添加属性name
            AddProperty(json, "name", "LISI");
            //添加属性info
            json.WritePropertyName("info");
                //开始写对象
                json.WriteObjectStart();
                    //添加属性lv
                    AddProperty(json, "lv", "2");
                    //添加属性info
                //停止写对象
                json.WriteObjectEnd();
        //停止写对象
        json.WriteObjectEnd();
        Debug.Log(json.ToString());

    }

    private void CreatJSONWithArray()
    {
        //{"name":"张三","Weapons":["Bow","Sword"]}
        //jsonWriter实例
        JsonWriter json = new JsonWriter();
        //开始写对象
        json.WriteObjectStart();

        //添加属性name
        AddProperty(json, "name", "LISI");
        //添加属性Weapons
        json.WritePropertyName("Weapons");
        //写数组
        json.WriteArrayStart();
        //写Bow
        json.Write("Bow");
        //写Sword
        json.Write("Sword");
        //停止写数组
        json.WriteArrayEnd();
        //停止写对象
        json.WriteObjectEnd();
        Debug.Log(json.ToString());
    }







    private void OnGUI()
    {
        if (GUILayout.Button("生成Json"))
        {
            CreatJSON();
        }

        if (GUILayout.Button("CreatCompositeJSON"))
        {
            CreatCompositeJSON();
        }
        if (GUILayout.Button("CreatJSONWithArray"))
        {
            CreatJSONWithArray();
        }





    }






    
}
