using System.Collections.Generic;
using System.Linq;

namespace Runner
{
    public class Sequencer : Singleton<Sequencer>
    {
        private Dictionary<string, Controller> _controllers = new();

        public void RegisterController(string id, Controller controller)
        {
            _controllers.Add(id, controller);
            controller.Init();
        }

        public void Play()
        {
            _controllers.Values.ToList().ForEach(controller => controller.StartSequence());
            OnSequencePlay?.Invoke();
        }
            

        public void Pause()
        {
            _controllers.Values.ToList().ForEach(controller => controller.StopSequence());
            OnSequenceStop?.Invoke();
        }

        private void Start()
        {
            Play();
        }

        public delegate void SequencePlay();
        public event SequencePlay OnSequencePlay;
        public delegate void SequenceStop();
        public event SequencePlay OnSequenceStop;
    }
}
