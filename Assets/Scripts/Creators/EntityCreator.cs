using BalloonSurfer.EntitySources;
using Leopotam.Ecs;

namespace BalloonSurfer.Creators
{
    public abstract class EntityCreator
    {
        public abstract void Init(EntitySource source, EcsEntity entity);
    }
}
