using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/MainData")]
public class MainData : ScriptableObject
{
    public PlayerInitData playerInitData;


    private static MainData _instance = null;
    public static MainData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<MainData>("MainData");
            }

            return _instance;
        }
    }
}
