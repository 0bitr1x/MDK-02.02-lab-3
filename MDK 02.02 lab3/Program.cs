using MDK_02._02_lab3.Interface;
using MDK_02._02_lab3.Servises;

OpticalSystem system = new OpticalSystem();

system.AddElement(new OpticalSurface("Передняя линза"));
system.AddElement(new OpticalPart("Фокусирующая группа"));
system.AddElement(new OpticalSurface("Задняя линза"));
system.AddElement(new OpticalConverter("Фотоумножитель"));
system.AddElement(new OpticalSurface("Финальная линза"));

Console.WriteLine("Расчет лучей");
CalculateRays(system);

Console.WriteLine("Визуализация системы");
VisualizeSystem(system);

Console.WriteLine("Статистика элементов");
PrintStatistics(system);

static void CalculateRays(OpticalSystem system)
{
    IOpticalIterator iterator = system.CreateIterator();
    int step = 1;

    Console.WriteLine("Выполняется расчет лучей:");
    while (iterator.MoveNext())
    {
        IOpticalElement element = iterator.Current;
        Console.WriteLine($"  Шаг {step}: Луч проходит через {element}");
        step++;
    }
}

static void VisualizeSystem(OpticalSystem system)
{
    IOpticalIterator iterator = system.CreateIterator();

    Console.WriteLine("Визуализация оптической системы:");
    while (iterator.MoveNext())
    {
        IOpticalElement element = iterator.Current;
        string symbol = element.Type switch
        {
            "Поверхность" => "--",
            "Деталь" => "$",
            "Преобразователь" => "&",
            _ => "•"
        };
        Console.WriteLine($"  {symbol} {element}");
    }
}

static void PrintStatistics(OpticalSystem system)
{
    IOpticalIterator iterator = system.CreateIterator();
    var statistics = new Dictionary<string, int>();

    while (iterator.MoveNext())
    {
        string type = iterator.Current.Type;
        if (statistics.ContainsKey(type))
            statistics[type]++;
        else
            statistics[type] = 1;
    }

    Console.WriteLine("Статистика по типам элементов:");
    foreach (var stat in statistics)
    {
        Console.WriteLine($"  {stat.Key}: {stat.Value}");
    }
}