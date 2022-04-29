using System;
using UnityEngine;

namespace Assets.Scripts
{
    internal class LevelScript : MonoBehaviour
    {
        public event Action OnStart;
        public event Action OnPlayerFall;
        private bool playerFall;

        [SerializeField] private GameObject player;
        [SerializeField] private float deadHeightTrigger;

        public UnitScript[] units { get; private set; }

        void Awake()
        {
            units = GameObject.FindObjectsOfType<UnitScript>();
        }

        void Start()
        {
            OnStart?.Invoke();
        }

        void FixedUpdate()
        {
            if(player.transform.position.y < deadHeightTrigger)
            {
                if (!playerFall)
                {
                    OnPlayerFall?.Invoke();
                    playerFall = true;
                }
            }
        }

    }
}
