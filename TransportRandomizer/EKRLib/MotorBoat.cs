/// <summary>
/// Библиотека классов.
/// </summary>
namespace EKRLib
{
    /// <summary>
    /// Класс-наследник от <c> Transport </c>.
    /// </summary>
    public class MotorBoat : Transport
    {
        /// <summary>
        /// Конструктор объекта <c> MotorBoat </c>.
        /// </summary>
        /// <param name="model"> Модель. </param>
        /// <param name="power"> Мощность. </param>
        public MotorBoat(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Переопределение <c> ToString </c>.
        /// </summary>
        /// <returns> Возвращает строку в формате <code> "MotorBoat. " + base.ToString() </code> </returns>
        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }

        /// <summary>
        /// Переопределение <c> StartEngine </c>.
        /// </summary>
        /// <returns> Возвращает строку в формате <code> "{Model}: Brrrbrr" </code> </returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }
    }
}
