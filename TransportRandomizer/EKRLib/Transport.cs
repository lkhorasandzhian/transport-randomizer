/// <summary>
/// Библиотека классов.
/// </summary>
namespace EKRLib
{
    /// <summary>
    /// Абстрактный класс транспортов.
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Наименование модели.
        /// </summary>
        private string _model;

        /// <summary>
        /// Мощность транспорта.
        /// </summary>
        private uint _power;

        /// <summary>
        /// Свойство для записи в поле <c> _model </c>.
        /// </summary>
        protected string Model
        {
            get => _model;
            set
            {
                if (value.Length != 5)
                    throw new TransportException($"Недопустимая модель {value}");

                for (int i = 0; i < 5; i++)
                {
                    char currentLetter = value[i];

                    if (!(currentLetter >= 'A' && currentLetter <= 'Z') &&
                        !(currentLetter >= '0' && currentLetter <= '9'))
                        throw new TransportException($"Недопустимая модель {value}");
                }

                _model = value;
            }
        }

        /// <summary>
        /// Свойство для записи в поле <c> _power </c>.
        /// </summary>
        protected uint Power
        {
            get => _power;
            set
            {
                if (value < 20)
                    throw new TransportException("мощность не может быть меньше 20 л.с.");

                _power = value;
            }
        }

        /// <summary>
        /// Конструктор для свойств <c> Model </c> и <c> Power </c>.
        /// </summary>
        /// <param name="model"> Аргумент для <c> Model </c>. </param>
        /// <param name="power"> Аргумент для <c> Power </c>. </param>
        protected Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Абстрактный метод двигателя.
        /// </summary>
        /// <returns></returns>
        public abstract string StartEngine();

        /// <summary>
        /// Переопределение <c> ToString </c>.
        /// </summary>
        /// <returns> Возвращает модель и мощность в формате <code> Model: {Model}, Power: {Power} </code> </returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }
    }
}
