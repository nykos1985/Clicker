using UnityEngine;


namespace Main
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        public abstract void Execute();
    }
}