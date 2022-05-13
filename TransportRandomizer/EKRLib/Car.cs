/// <summary>
/// Библиотека классов.
/// </summary>
namespace EKRLib
{
    /// <summary>
    /// Класс-наследник от <c> Transport </c>.
    /// </summary>
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор объекта <c> Car </c>.
        /// </summary>
        /// <param name="model"> Модель. </param>
        /// <param name="power"> Мощность. </param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Переопределение <c> ToString </c>.
        /// </summary>
        /// <returns> Возвращает строку в формате <code> "Car. " + base.ToString() </code> </returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }

        /// <summary>
        /// Переопределение <c> StartEngine </c>.
        /// </summary>
        /// <returns> Возвращает строку в формате <code> "{Model}: Vroom" </code> </returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }
    }
}
