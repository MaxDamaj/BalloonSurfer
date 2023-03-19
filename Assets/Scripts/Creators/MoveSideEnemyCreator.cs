using BalloonSurfer.Components;
using BalloonSurfer.EntitySources;
using Leopotam.Ecs;

namespace BalloonSurfer.Creators
{
    public class MoveSideEnemyCreator : EnemyCreator
    {
        public override void Init(EntitySource source, EcsEntity entity)
        {
            var enemyData = source as MoveSideEnemySource;
            base.Init(source, entity);
            InitMoveLeftRight(entity, enemyData);
        }

        public override void Mutate(MutableSource source, EcsEntity entity)
        {
            var enemyData = source as MoveSideEnemySource;
            base.Mutate(source, entity);
            InitMoveLeftRight(entity, enemyData);
        }


        private void InitMoveLeftRight(EcsEntity entity, EnemySource enemyData)
        {
            var leftRightData = enemyData as MoveSideEnemySource;

            ref var spawnable = ref entity.Get<SpawnableComponent>();
            ref var leftRight = ref entity.Get<MoveLeftRightComponent>();

            leftRight.transform = spawnable.transform;
            leftRight.speed = leftRightData.sideSpeed;
            leftRight.StartMove();
        }
    }
}
