using TestShooter.Scripts.Movement;
using UnityEngine;

namespace TestShooter.Scripts.Enemy
{
    internal class PatrolScript : MonoBehaviour
    {
        [SerializeField] private Transform[] paths;

        private int pathIndex = 0;
        private bool direciton;

        [SerializeField] private MoveScript _moveScript;

        [Range(0f, 10f), SerializeField] private float speed = 3f;

        void Awake()
        {

        }

        void FixedUpdate()
        {
            if (paths.Length == 0)
                return;

            var delta = paths[pathIndex].position - _moveScript.transform.position;
            if (delta.magnitude <= speed * Time.fixedDeltaTime)
            {
                pathIndex += direciton ? -1 : 1;
                if (pathIndex >= paths.Length || pathIndex < 0)
                {
                    direciton = !direciton;
                    pathIndex += direciton ? -2 : 2;
                }
            }

            var distanse = new Vector2(delta.x, delta.z).normalized * speed;

            _moveScript.distanse = distanse;
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
