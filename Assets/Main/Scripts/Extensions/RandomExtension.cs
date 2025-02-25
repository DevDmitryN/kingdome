using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Extensions
{
    public static class RandomExtension
    {
        public static bool Bool(float probabilityOfTrue)
        {
            var random = new System.Random();
            return random.NextDouble() < probabilityOfTrue;
        }

        public static int Int(int min, int max)
        {
            var random = new System.Random();
            return random.Next(min, max);
        }
        
        public  static int GetRandomIndex(List<double> probabilities)
        {
            // Создаем генератор случайных чисел
            var random = new System.Random();

            // Генерируем случайное число от 0 до 1
            double randomValue = random.NextDouble();

            // Вычисляем кумулятивные суммы вероятностей
            double cumulative = 0.0;

            // Идем по массиву вероятностей и ищем, где попало случайное число
            for (int i = 0; i < probabilities.Count; i++)
            {
                cumulative += probabilities[i];
                if (randomValue < cumulative)
                {
                    return i;
                }
            }

            // Если не найдено (например, из-за ошибок округления), возвращаем последний индекс
            return 0;
        }
        
        public static Vector3 GenerateRandomCoordinates(Vector3 centerPoint, float minRadius, float maxRadius)
        {
            // Генерируем случайное значение в диапазоне от 0 до 2π (полный круг)
            float randomAngle = Random.Range(0, 360);
            // Генерируем случайное расстояние от центра точки до случайной точки
            float randomRadius = Random.Range(minRadius, maxRadius);
            // Вычисляем координаты случайной точки в полярных координатах
            float x = centerPoint.x + randomRadius * Mathf.Cos(Mathf.Deg2Rad * randomAngle);
            float y = centerPoint.y + randomRadius * Mathf.Sin(Mathf.Deg2Rad * randomAngle);
            // Создаем новую позицию с случайными координатами
            return new Vector3(x, y, centerPoint.z);
        }
    }
}