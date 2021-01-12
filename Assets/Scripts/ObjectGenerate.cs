using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerate : MonoBehaviour
{
    //配置する距離
    public Vector3 offset = new Vector3();

    //カメラ＆Prefab登録
    public GameObject cam;
    public GameObject Prefab;

    //Prefab生成処理
    public void GeneratePrefab()
    {
        Vector3 position = cam.transform.position + transform.forward * offset.z;
        Instantiate(Prefab, position, transform.rotation);
    }
}
