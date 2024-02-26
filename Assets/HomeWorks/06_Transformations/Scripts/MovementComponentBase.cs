using UnityEngine;

namespace HomeWorks._06_Transformations.Scripts
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