using UnityEngine;
namespace NW
{
    public class SlimeSpawnerInstance : MonoBehaviour, IInstance
    {
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private Transform _slime;
        [SerializeField] private Transform _baseTransform;
        [SerializeField, Range(0, 100)] private float _startRadius;
        [SerializeField, Range(0, 100)] private float _endRadius;
        private SlimeSpawnerPresentation _slimePresentation;

        public DataReader DataReader { get; private set; } = new MonsterReader();

        private void Awake()
        {
            _slimePresentation = new SlimeSpawnerPresentation(_baseTransform, _slime, _jumpCurve);
            _slimePresentation.StartRadius = _startRadius;
            _slimePresentation.EndRadius = _endRadius;
        }

        public void SetMediator(IMediatorInstance mediator)
        {
        }

        public void InstreamData(byte[] data)
        {
            _slimePresentation.InstreamData(data);
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Util.DrawGizmos.DrawCircle((_baseTransform?.position ?? Vector3.zero) + Vector3.up * _jumpCurve.keys[0].value, _startRadius);
            Util.DrawGizmos.DrawCircle((_baseTransform?.position ?? Vector3.zero) + Vector3.up * _jumpCurve.keys[^1].value, _endRadius);
            Util.DrawGizmos.DrawCurve(CalculatePointOnCircle(_startRadius, _jumpCurve.keys[0].value), CalculatePointOnCircle(_endRadius, _jumpCurve.keys[^1].value), _jumpCurve);
        }
        private Vector3 CalculatePointOnCircle(float radius, float heightOffset = 0f)
        {
            return (_baseTransform?.position ?? Vector3.zero)
                + new Vector3(Mathf.Cos(0) * radius,
                              heightOffset,
                              Mathf.Sin(0) * radius);
        }
    }

}