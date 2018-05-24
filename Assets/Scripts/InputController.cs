using Unity;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public struct ButtonPressedInfo
    {
        public enum ButtonMode
        {
            PRESSED,
            TAPPED,
            HOLD
        };

        public float intensity;
        public ButtonMode mode;
    };

    public delegate void InputEvent(ButtonPressedInfo info);

    public class InputContext
    {
        public Dictionary<int, InputEvent> reactions;

        public InputContext()
        {
            this.reactions = new Dictionary<int, InputEvent>();
        }

        public void AddInputReaction(int key, InputEvent reaction)
        {
            if (!this.reactions.ContainsKey(key))
                this.reactions.Add(key, reaction);
        }
        public void RemoveInputReaction(int key)
        {
            if (this.reactions.ContainsKey(key))
                this.reactions.Remove(key);
        }

        public InputEvent GetInputReaction(int key)
        {
            if (this.reactions.ContainsKey(key))
                return this.reactions[key];

            return null;
        }
        public bool isActive { get; set; }
        public int activeReactions { get { return this.reactions.Count; } }
    }

    class InputController
    {
        List<InputContext> contextList;

        public InputController()
        {
            this.contextList = new List<InputContext>();
            this.contextList.Add(new InputContext());
        }

        public void Update()
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");

            foreach (var inputContext in this.contextList)
            {
                if (inputContext.isActive)
                {
                    foreach(KeyCode key in Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            ButtonPressedInfo info;
                            info.mode = ButtonPressedInfo.ButtonMode.PRESSED;
                            info.intensity = 1.0f;

                            var reaction = inputContext.GetInputReaction((int)key);
                            reaction(info);
                        }
                    }

                    if (hAxis != 0.0f)
                    {
                        ButtonPressedInfo info;
                        info.mode = ButtonPressedInfo.ButtonMode.HOLD;
                        info.intensity = hAxis;

                        var reaction = inputContext.GetInputReaction(-1);
                        reaction(info);
                    }
                    if (vAxis != 0.0f)
                    {
                        ButtonPressedInfo info;
                        info.mode = ButtonPressedInfo.ButtonMode.HOLD;
                        info.intensity = vAxis;

                        var reaction = inputContext.GetInputReaction(-2);
                        reaction(info);
                    }
                }
            }
        }
    }
}
