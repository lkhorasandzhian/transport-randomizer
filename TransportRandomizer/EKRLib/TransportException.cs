using System;

/// <summary>
/// Библиотека классов.
/// </summary>
namespace EKRLib
{
    /// <summary>
    /// Класс исключений для типа Transport.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public TransportException() { }

        /// <summary>
        /// Конструктор с параметром <c> message </c>.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        public TransportException(string message) : base(message) { }

        /// <summary>
        /// Конструктор с параметром <c> message </c> и <c> inner </c>.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <param name="inner"> Внутренний. </param>
        public TransportException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Конструктор с параметром <c> info </c> и <c> context </c>.
        /// </summary>
        /// <param name="info"> Информация. </param>
        /// <param name="context"> Контекст. </param>
        protected TransportException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
