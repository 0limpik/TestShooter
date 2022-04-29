using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestShooter.Scripts
{
    internal class LevelScript : MonoBehaviour
    {
        public event Action OnStart;
        public event Action OnEnterFinish;
        public event Action OnPlayerFall;
        private bool gameEnd;

        [SerializeField] private GameObject _playerUnit;
        [SerializeField] private float fallHeightTrigger;
        [SerializeField] private TriggerScript _finishTrigger;

        [SerializeField] private float restartLevelTime = 4f;

        public List<UnitScript> Units { get; private set; }

        private bool inFinishTrigger;

        void Awake()
        {
            Units = GameObject.FindObjectsOfType<UnitScript>().ToList();
            _finishTrigger.OnTriggerEnterEvent += FinishCollider_OnTriggerEnter;
            _finishTrigger.OnTriggerExitEvent += _finishTrigger_OnTriggerExit; ;
        }

        void Start()
        {
            OnStart?.Invoke();
        }

        private void FinishCollider_OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject == _playerUnit)
                inFinishTrigger = true;
        }

        private void _finishTrigger_OnTriggerExit(Collider collider)
        {
            if (collider.gameObject == _playerUnit)
                inFinishTrigger = false;
        }

        void FixedUpdate()
        {
            if (!gameEnd)
            {
                if (_playerUnit.transform.position.y < fallHeightTrigger)
                {
                    OnPlayerFall?.Invoke();
                    EndGame();
                }

                if (inFinishTrigger && Units.Count <= 1)
                {
                    OnEnterFinish?.Invoke();
                    EndGame();
                }
            }

            foreach (var unit in Units.ToArray())
            {
                if (unit.gameObject != _playerUnit)
                    if (unit.transform.position.y < fallHeightTrigger)
                    {
                        Destroy(unit.gameObject.transform.parent.gameObject);
                        Units.Remove(unit);
                    }
            }
        }

        private void EndGame()
        {
            gameEnd = true;
            StartCoroutine(nameof(ReloadLevel));
        }

        private IEnumerator ReloadLevel()
        {
            yield return new WaitForSeconds(restartLevelTime);
            SceneManager.LoadScene("Level");
        }
    }
}
