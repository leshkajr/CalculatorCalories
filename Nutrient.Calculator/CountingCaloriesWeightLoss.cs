﻿using DbCalculatorСalorie.Models;
using System;

namespace Nutrient.Calculator
{
    /// <summary>
    /// Считает нужное количество калорий для того, чтобы сборсить вес
    /// </summary>
    public class CountingCaloriesWeightLoss : NutrientCalories, ICalculator
    {
        /// <summary>
        /// Возвращает Product;
        /// Calories = нужное кол-во калорий,
        /// Protein = нужное кол-во белков,
        /// Fats = нужное кол-во жиров,
        /// Carbohydrates = нужное кол-во углеводов;
        /// 
        /// Все остальные поля класса Product не изменены.
        /// </summary>
        /// <param name="product">Игнорируется</param>
        /// <param name="user">Используется для подсчёта кол-ва калорий (Height, Weight, Age)</param>
        /// <param name="date">Игнорируется</param>
        /// <returns>Класс Product с полями значения которых указаны в описании</returns>
        public Product NutrientCount(Product product, User user, DateTime date)
        {
            double needed_calories = (655 + (user.Height * 1.8) + (user.Weight * 9.6) - (user.Age * 4.7)) * 1.38 - 200;
            return new Product() { Calories = (int)needed_calories, Protein = (int)(needed_calories * 0.27), Fats = (int)(needed_calories * 0.27), Carbohydrates = (int)(needed_calories * 0.46) };
        }
    }
}