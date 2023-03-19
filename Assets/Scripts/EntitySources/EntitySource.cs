using BalloonSurfer.Creators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalloonSurfer.EntitySources
{
    public abstract class EntitySource : MonoBehaviour
    {
        public EntityCreator Creator { get; protected set; }

        public abstract void SetCreator();

    }
}
