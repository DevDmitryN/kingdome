using Main.Scripts.Gameplay.Features.GameResources.Enums;

namespace Main.Scripts.Gameplay.Features.GameResources.Models.Events
{
    public class ResourceAmountChanged
    {
        public GameResourceType Type;
        /// <summary>
        /// На сколько изменилось
        /// </summary>
        public float ChangeValue;
        /// <summary>
        /// Предыдущее значение
        /// </summary>
        public float PrevValue;
        /// <summary>
        /// Новое значение
        /// </summary>
        public float NewValue;
    }
}