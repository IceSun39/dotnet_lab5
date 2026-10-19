namespace lab5.Classes
{
    // Результат проекції: вартість однієї позиції (ціна * кількість)
    public record ProductValue(string Type, string Grade, double TotalValue);

    // Результат групування за типом: статистика по кожному типу продукції
    public record TypeStatistic(string Type, int ProductsCount, int TotalAmount, double AveragePrice);
}
