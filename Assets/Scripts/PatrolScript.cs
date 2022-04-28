using UnityEngine;

namespace Assets.Scripts
{
    internal class PatrolScript : MonoBehaviour
    {
        [SerializeField] private Transform[] paths;

        private int pathIndex = 0;

        [SerializeField] private GameObject _unit;
         private Rigidbody _rigidbody;

        [Range(0f, 10f), SerializeField] private float speed = 3f;

        void Awake()
        {
            _rigidbody = _unit.GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (paths.Length == 0)
                return;

            var delta = paths[pathIndex].position - _unit.transform.position;
            if (delta.magnitude <= speed * Time.fixedDeltaTime)
            {
                pathIndex++;
                if (pathIndex >= paths.Length)
                {
                    pathIndex = 0;
                }
            }

            _rigidbody.MovePosition(_unit.transform.position + delta.normalized * speed * Time.fixedDeltaTime);
        }

        void OnDrawGizmos()
        {
            for (int i = 0; i < paths.Length; i++)
            {
                var path = paths[i];

                if (i == pathIndex)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawSphere(path.position, 0.25f);
                }
                else
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(path.position, 0.25f);
                }
            }
        }
    }
}
