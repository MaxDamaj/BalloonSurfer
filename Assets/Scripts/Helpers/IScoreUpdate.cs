using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.Helpers
{
    public interface IScoreUpdate
    {
        public void UpdateScore(int scoreValue);
    }
}
