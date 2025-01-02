using UnityEngine;

namespace _src.Scripts.UI.Core
{
    public abstract class UiWindow : MonoBehaviour
    {
        [SerializeField] protected GameObject _content;
        
        protected enum State : byte
        {
            None = 0,
            Shown = 1,
            Hidden = 2,
        }

        protected State _state = State.None;

        protected void Awake()
        {
            Hide();
        }

        protected void OnEnable()
        {
            UiController.AddWindow(this); 
        }

        protected void OnDisable()
        {
            UiController.RemoveWindow(this);
        }

        public void Show()
        {
            if (_state == State.Shown)
                return;

            _state = State.Shown;
            _content.SetActive(true);
                
                
            OnShown();
        }

        public void Hide()
        {
            if (_state == State.Hidden)
                return;

            _state = State.Hidden;
            _content.SetActive(false);
            
            
            OnHidden();
        }

        protected virtual void OnShown()
        {
        }
        
        protected virtual void OnHidden()
        {
        }
    }
}