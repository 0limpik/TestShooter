using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace TestShooter.Scripts.UI
{
    [RequireComponent(typeof(UIDocument))]
    internal class ResultUIScript : MonoBehaviour
    {
        private UIDocument document;
        [SerializeField] private LevelScript level;

        private const string WinMessage = "Win";
        private const string LoseMessage = "Lose";

        private Label messageLable;

        void Awake()
        {
            document = GetComponent<UIDocument>();
            messageLable = document.rootVisualElement.Q<Label>("message");
            messageLable.text = null;

            level.OnEnterFinish += () => DisplayMessage(WinMessage, Color.green);
            level.OnPlayerFall += () => DisplayMessage(LoseMessage, Color.red);
        }

        public async void DisplayMessage(string message, Color color)
        {
            messageLable.text = message;
            messageLable.style.color = color;

            await Task.Delay(3000);

            messageLable.text = null;
        }
    }
}
