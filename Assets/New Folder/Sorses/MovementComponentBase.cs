using UnityEngine;

namespace New_Folder.Sorses
{
    public abstract class MovementComponentBase : MonoBehaviour
    {
        private void Update()
        {
            Move();            
        }

        protected abstract void Move();

    }
}