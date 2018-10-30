using System;
using System.Collections.Generic;

namespace JustAnotherConsoleGame.Input
{
    public class InputManager
    {
        public bool IsRunning { get; private set; }

        private Dictionary<ConsoleKey, List<Action>> bindings = new Dictionary<ConsoleKey, List<Action>>();

        public void AddBinding(ConsoleKey key, Action action)
        {
            this.bindings.TryGetValue(key, out List<Action> actions);

            if (actions == null)
            {
                actions = new List<Action>();
                actions.Add(action);
                this.bindings.Add(key, actions);
            }
            else
            {
                actions.Add(action);
                this.bindings[key] = actions;
            }
        }

        public InputManager Bind(Action action, params ConsoleKey[] keys)
        {
            foreach (var key in keys)
                this.AddBinding(key, action);

            return this;
        }

        public void Run()
        {
            this.IsRunning = true;

            while (this.IsRunning)
                if (this.bindings.TryGetValue(Console.ReadKey(true).Key, out List<Action> actions))
                    actions.ForEach(x => x.Invoke());
        }

        public void Stop()
        {
            this.IsRunning = false;
        }
    }
}
