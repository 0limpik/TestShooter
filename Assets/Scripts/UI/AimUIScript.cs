using UnityEngine;
using UnityEngine.UIElements;

namespace TestShooter.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    internal class AimUIScript : MonoBehaviour
    {
        private UIDocument _document;

        private Camera _camera;

        private Color aimColor;

        VisualElement up;
        VisualElement down;
        VisualElement left;
        VisualElement right;

        void Awake()
        {
            _document = GetComponent<UIDocument>();
            _camera = Camera.main;

            var tree = _document.rootVisualElement.Q("aim");
            up = tree.Q("up");
            down = tree.Q("down");
            left = tree.Q("left");
            right = tree.Q("right");
        }

        void Update()
        {
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit))
            {
                var unit = hit.collider.gameObject.GetComponent<UnitScript>();
                if (unit != null)
                {
                    ChangeAimColor(Color.yellow);
                }
                else
                {
                    ChangeAimColor(Color.red);
                }
            }
            else
            {
                ChangeAimColor(Color.red);
            }
        }

        private void ChangeAimColor(Color color)
        {
            if (aimColor == color)
                return;

            aimColor = color;

            up.style.backgroundColor = color;
            down.style.backgroundColor = color;
            left.style.backgroundColor = color;
            right.style.backgroundColor = color;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            if (_camera != null)
            {
                Gizmos.DrawLine(_camera.transform.position, _camera.transform.forward * 100);
            }
        }

    }
}
