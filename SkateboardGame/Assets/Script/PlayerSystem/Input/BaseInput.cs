using UnityEngine;

namespace SkateboardGame.PlayerSystem
{

    public interface IInput
    {
        Vector2 GenerateInput();
    }

    public abstract class BaseInput : MonoBehaviour, IInput
    {        
        public abstract Vector2 GenerateInput();
    }
}
