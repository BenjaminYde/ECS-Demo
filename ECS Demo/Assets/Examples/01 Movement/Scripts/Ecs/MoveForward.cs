using Unity.Entities;

namespace Movement01
{
    [GenerateAuthoringComponent]
    public struct MoveForward : IComponentData
    {
        public float Speed;
        public float MaxMovePositionZ;
        public bool DoHeavyCalculation;
    }
}
