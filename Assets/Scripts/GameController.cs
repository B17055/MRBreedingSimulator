using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void DeleteAllFurniture()
    {
        GameObject[] furnitures = GameObject.FindGameObjectsWithTag("furniture");
        foreach (GameObject furniturelist in furnitures)
        {
            Destroy(furniturelist);
        }
    }

    public void Gamequit()
    {
        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
         UnityEngine.Application.Quit();
        #endif
    }
}
