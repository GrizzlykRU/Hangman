using UnityEngine;

namespace Utility
{
    public class GameobjectExtensions : MonoBehaviour
    {
        public void SetInactive(bool isInactive)
        {
            gameObject.SetActive(!isInactive);
        }
    }
}