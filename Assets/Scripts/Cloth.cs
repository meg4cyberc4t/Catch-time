using UnityEngine;

namespace Assets.Scripts
{
    public class Cloth : MonoBehaviour
    {
        // public string Title;
        // // We need it?)
        [Range(1, 3)] public int Weight;
        // 1 - Носки
        // 2 - Футболки, штаны, рубашки
        // 3 - Тулуп, кофты
    }
}