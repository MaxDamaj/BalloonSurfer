using GG.Infrastructure.Utils.Swipe;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private SwipeListener _swipeListener = null;

    public event Action<int> OnSwipe;

    #region Instance

    private static SwipeDetector _instance = null;
    public static SwipeDetector Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SwipeDetector>();
            }

            return _instance;
        }
    }

    #endregion

    void Start() {
        _swipeListener.OnSwipe.AddListener(Swipe);
    }

    public void Swipe(string swipe)
    {
        if (swipe == "Right" || swipe == "Left")
        {
            OnSwipe?.Invoke(swipe == "Right" ? 1 : -1);
        }
    }
}
