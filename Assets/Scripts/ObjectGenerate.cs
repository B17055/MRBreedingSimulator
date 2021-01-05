using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerate : MonoBehaviour
{
    //配置する距離
    public Vector3 offset = new Vector3();

    //Prefab登録
    public GameObject CagePrefab;

    //Prefab生成処理_Cage
    public void GenerateCage()
    {
        Vector3 position = transform.position +
                transform.up * offset.y +
                transform.right * offset.x +
                transform.forward * offset.z;
        Instantiate(CagePrefab, position, transform.rotation);
    }
}
