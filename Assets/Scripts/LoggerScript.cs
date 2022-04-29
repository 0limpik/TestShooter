﻿using System;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    internal class LoggerScript : MonoBehaviour
    {
        [SerializeField] private LevelScript levelScript;

        [SerializeField] private bool writeToDebugConsole;
        [SerializeField] private string path;

        private void Awake()
        {
            levelScript.OnStart += () => WriteMessage("Game Start");
            levelScript.OnPlayerFall += () => WriteMessage("Player fall");

            foreach (var unit in levelScript.units)
            {
                unit.OnHit += (s) => WriteMessage($"{s.name} hitted by {unit.Owner.name}");
                unit.GunScript.OnShoot += () => WriteMessage($"{unit.Owner.name} shoot");
            }
        }

        private async void WriteMessage(string message)
        {
            if (writeToDebugConsole)
            {
                Debug.Log(message);
            }

            var writer = new StreamWriter("log.txt", true);
            await writer.WriteLineAsync($"[{DateTime.Now:yyyy:MM:dd HH:mm:ss:}] {message}");
            writer.Close();
            writer.Dispose();
        }
    }
}