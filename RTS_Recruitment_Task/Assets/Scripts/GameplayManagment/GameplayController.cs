using System;
using System.Collections.Generic;
using UnityEngine;

namespace Recruitment.GameplayManagment
{
    public class GameplayController : MonoBehaviour
    {
        public Action GameEnded = delegate { };
        public Action<float> TimerValueChanged = delegate { };

        [field: SerializeField]
        private List<MonoBehaviour> PlayerMechanicCollection = new();

        public bool IsKeyCollected { get; set; }
        public float CurrentTime { get; private set; }
        public float BestTime { get; private set; }
        public bool IsTimerStop { get; private set; } = true;
        private int LastSecond { get; set; }

        public void StartGame ()
        {
            IsKeyCollected = false;
            ResetTimer();
            SetPlayerMechanicsEnableState(true);
        }

        public void EndGame ()
        {
            SetPlayerMechanicsEnableState(false);
            IsTimerStop = true;
            GameEnded.Invoke();
        }

        public void SetPlayerMechanicsEnableState (bool state)
        {
            for (int index = 0; index < PlayerMechanicCollection.Count; index++)
            {
                PlayerMechanicCollection[index].enabled = state;
            }
        }

        protected virtual void Update ()
        {
            TimerCountdown();
        }

        private void ResetTimer ()
        {
            IsTimerStop = false;
            CurrentTime = 0.0f;
            LastSecond = 0;
            TimerValueChanged.Invoke(CurrentTime);
        }

        private void TimerCountdown ()
        {
            if (IsTimerStop == false)
            {
                CurrentTime += Time.deltaTime;

                if (LastSecond < (int)CurrentTime)
                {
                    LastSecond = (int)CurrentTime;
                    TimerValueChanged.Invoke(CurrentTime);
                }
            }
        }
    }
}