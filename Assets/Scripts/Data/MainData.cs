using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.InitData
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MainData")]
    public class MainData : ScriptableObject
    {
        [SerializeField] private List<InitData> _initDatas = null;

        private Dictionary<Type, InitData> _initDataDictionary = null;
        private static MainData _instance = null;


        public static T GetData<T>() where T : InitData
        {
            if (_instance == null)
            {
                _instance = Resources.Load<MainData>("MainData");
            }

            if (_instance._initDataDictionary == null)
            {
                _instance._initDataDictionary = new Dictionary<Type, InitData>();
                foreach (var data in _instance._initDatas)
                {
                    _instance._initDataDictionary[data.GetType()] = data;
                }
            }

            return (T)_instance._initDataDictionary[typeof(T)];
        }
    }
}
