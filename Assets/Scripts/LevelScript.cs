using System;
using System.Collections;
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

        [SerializeField] private GameObject player;
        [SerializeField] private float deadHeightTrigger;
        [SerializeField] private TriggerScript finishTrigger;

        [SerializeField] private float restartLevelTime = 4f;

        public UnitScript[] units { get; private set; }

        void Awake()
        {
            units = GameObject.FindObjectsOfType<UnitScript>();
            finishTrigger.OnTrigger += FinishCollider_OnTrigger;
        }

        void Start()
        {
            OnStart?.Invoke();
        }

        private void FinishCollider_OnTrigger(Collider collider)
        {
            if (collider.gameObject == player)
                if (!gameEnd)
                {
                    OnEnterFinish?.Invoke();
                    EndGame();
                }
        }

        void FixedUpdate()
        {
            if (player.transform.position.y < deadHeightTrigger)
            {
                if (!gameEnd)
                {
                    OnPlayerFall?.Invoke();
                    EndGame();
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
