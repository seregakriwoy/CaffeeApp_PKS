using System;

namespace Restaurant
{
        public enum DishCategory
    {
        Напитки,
        Салаты,
        Холодные_Закуски,
        Горячие_Закуски,
        Супы,
        Горячие_Блюда,
        Десерты,
        Выпечка,
        Гарниры
    }
    public class Dish
{
    public int id_dish { get; private set; }
    public string name_dish { get; private set; }
    public string ingridients { get; private set; }
    public int weight_dish { get; private set; }
    public double price_dish { get; private set; }
    public int cooking_time { get; private set; }
    public List<string> type_dish { get; private set; }
    public DishCategory category_dish { get; private set; }
    public bool delete_status { get; private set; }

    public Dish(int id, string name, string composition, int weight, double price,
           DishCategory category, int cookingTime, List<string> types, bool Delete_Status)
    {
        id_dish = id;
        name_dish = name;
        ingridients = composition;
        weight_dish = weight;
        price_dish = price;
        category_dish = category;
        cooking_time = cookingTime;
        type_dish = types ?? new List<string>();
        delete_status = Delete_Status;
    }

    public static Dish createDish(int id, string name, string composition, int weight, double price,
                                 DishCategory category, int cookingTime, List<string> types)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название блюда не может быть пустым");
        
        if (price < 0)
            throw new ArgumentException("Цена не может быть отрицательной");
        
        if (cookingTime < 0)
            throw new ArgumentException("Время готовки не может быть отрицательным");

        if (weight < 0)
            throw new ArgumentException("Вес не может быть отрицательным");

        return new Dish(id, name, composition, weight, price, category, cookingTime, types, false);
    }

    public void deleteDish() //удаление блюда
    {
        if (delete_status)
        {
            throw new InvalidOperationException("Блюдо уже удалено");
        }
        delete_status = true;
    }

    public void editDish(string name = null, string composition = null, int? weight = null, 
                        double? price = null, DishCategory? category = null, 
                        int? cookingTime = null, List<string> types = null)
    {
        if (!string.IsNullOrWhiteSpace(name))
            name_dish = name;
        
        if (!string.IsNullOrWhiteSpace(composition))
            ingridients = composition;
        
        if (weight.HasValue && weight.Value >= 0)
            weight_dish = weight.Value;
        
        if (price.HasValue && price.Value >= 0)
            price_dish = price.Value;
        
        if (category.HasValue)
            category_dish = category.Value;
        
        if (cookingTime.HasValue && cookingTime.Value >= 0)
            cooking_time = cookingTime.Value;
        
        if (types != null)
            type_dish = types;
    }

    public void printDish() //вывод информации о блюде
    {
        if (delete_status)
        {
            Console.WriteLine("=== БЛЮДО УДАЛЕНО ===");
            return;
        }
        else
        {
                Console.WriteLine("=== ИНФОРМАЦИЯ О БЛЮДЕ ===");
                Console.WriteLine($"ID: {id_dish}");
                Console.WriteLine($"Название: {name_dish}");
                Console.WriteLine($"Состав: {ingridients}");
                Console.WriteLine($"Вес: {weight_dish} г");
                Console.WriteLine($"Цена: {price_dish:C}");
                Console.WriteLine($"Категория: {category_dish}");
                Console.WriteLine($"Время готовки: {cooking_time} мин");
                Console.WriteLine($"Типы: {string.Join(", ", type_dish)}");
                Console.WriteLine("==========================");
                Console.WriteLine();
        }
    }
}
}

