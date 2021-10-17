using System.Threading;

namespace Async
{
    /// <summary>
    /// Класс эмулирующий работу с источником данных.
    /// Этот класс не должен меняться!
    /// </summary>
    internal class FakeDB
    {
        /// <summary>
        /// Возвращает переданные ему данные спустя интервал времени
        /// </summary>
        /// <typeparam name="T">Тип данных</typeparam>
        /// <param name="data">Данные которые класс вернет</param>
        /// <returns>Данные переданные в метод</returns>
        public T GetData<T>(T data)
        {
            Thread.Sleep(1000);
            return data;
        }
    }
}
