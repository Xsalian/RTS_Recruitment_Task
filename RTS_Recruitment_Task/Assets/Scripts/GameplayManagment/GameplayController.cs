using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recruitment.GameplayManagment
{
    public class GameplayController : MonoBehaviour
    {
        public Action GameEnded = delegate { };
        public Action<float> TimerValueChanged = delegate { };

        [field: SerializeField]
        private List<MonoBehaviour> PlayerMechanicCollection { get; set; } = new();
        [field: SerializeField]
        private GameObject SuccessEffect { get; set; }
        [field: SerializeField]
        private float EffectDuration { get; set; }

        public bool IsKeyCollected { get; set; }
        public float CurrentTime { get; private set; }
        public bool IsTimerStop { get; private set; } = true;
        private int LastSecond { get; set; }
        private WaitForSeconds WaitForEffectDuration { get; set; }

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
            SuccessEffect.SetActive(true);
            StartCoroutine(WaitForEffectEnd());
        }

        public void SetPlayerMechanicsEnableState (bool state)
        {
            for (int index = 0; index < PlayerMechanicCollection.Count; index++)
            {
                PlayerMechanicCollection[index].enabled = state;
            }
        }

        protected virtual void Awake ()
        {
            Initialize();
        }

        protected virtual void Update ()
        {
            TimerCountdown();
        }

        private void Initialize ()
        {
            WaitForEffectDuration = new WaitForSeconds(EffectDuration);
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

        private IEnumerator WaitForEffectEnd ()
        {
            yield return WaitForEffectDuration;
            SuccessEffect.SetActive(false);
            GameEnded.Invoke();
        }
    }
}