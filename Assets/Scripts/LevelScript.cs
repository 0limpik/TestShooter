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

        void Awake()
        {
            Units = GameObject.FindObjectsOfType<UnitScript>().ToList();
            _finishTrigger.OnTrigger += FinishCollider_OnTrigger;
        }

        void Start()
        {
            OnStart?.Invoke();
        }

        private void FinishCollider_OnTrigger(Collider collider)
        {
            if (collider.gameObject == _playerUnit)
                if (!gameEnd)
                {
                    OnEnterFinish?.Invoke();
                    EndGame();
                }
        }

        void FixedUpdate()
        {
            if (_playerUnit.transform.position.y < fallHeightTrigger)
            {
                if (!gameEnd)
                {
                    OnPlayerFall?.Invoke();
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
