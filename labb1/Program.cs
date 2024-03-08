Console.WriteLine("ЧАСТЬ 1\n");
Console.Write("Введите размер массива n: ");
var isValid = int.TryParse(Console.ReadLine(), out var n);
if (!isValid || n <= 0)
{
    Console.WriteLine("Неверный размер массива.");
    return;
}

// Заполнение массива
var random = new Random();
int[] arr = new int[n];
for (int i = 0; i < n; i++)
{
    arr[i] = random.Next(-100, 100);
}

// Вычисление произведения элементов массива с четными номерами
int productEvenIndices = 1;
for (int i = 0; i <n; i += 2)
{
    productEvenIndices *= arr[i];
}
Console.WriteLine($"Произведение элементов массива с четными номерами: {productEvenIndices}");
        
// Вычисление суммы элементов массива между первым и последним нулевыми элементами
int sumBetweenZeroes = 0;
bool hasFirstZero = false;
foreach (var t in arr)
{
    if (t == 0)
    {
        if (hasFirstZero)
            break;
        hasFirstZero = true;
    }
    else if (hasFirstZero)
    {
        sumBetweenZeroes += t;
    }
}
Console.WriteLine($"Сумма элементов массива между первым и последним нулевыми элементами: {sumBetweenZeroes}");
        
// Преобразование массива: положительные элементы, затем отрицательные
arr = arr.OrderByDescending(x => x >= 0).ToArray();
        
Console.WriteLine("Преобразованный массив:");
foreach (var item in arr)
{
    Console.Write($"{item} ");
}
Console.WriteLine();


Console.WriteLine("ЧАСТЬ 2\n");
Console.Write("Введите количество строк матрицы: ");
isValid = int.TryParse(Console.ReadLine(), out var a);
if (!isValid || a <= 0)
{
    Console.WriteLine("Неверный размер массива.");
    return;
}
Console.Write("Введите количество столбцов матрицы: ");
isValid = int.TryParse(Console.ReadLine(), out var b);
if (!isValid || b <= 0)
{
    Console.WriteLine("Неверный размер массива.");
    return;
}
int[,] matrix = new int[a,b];
for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {
        matrix[i, j] = random.Next(-100, 100);
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}


// Определение количества столбцов, содержащих хотя бы один нулевой элемент
int columnsWithZero = 0;
for (int j = 0; j < b; j++)
{
    for (int i = 0; i <a; i++)
    {
        if (matrix[i, j] == 0)
        {
            columnsWithZero++;
            break;
        }
    }
}
Console.WriteLine($"Количество столбцов, содержащих хотя бы один нулевой элемент: {columnsWithZero}");

// Определение номера строки с самой длинной серией одинаковых элементов
int longestSeriesRow = -1;
int longestSeriesLength = 0;
for (int i = 0; i < a; i++)
{
    int currentLength = 1;
    for (int j = 1; j < b; j++)
    {
        if (matrix[i, j] == matrix[i, j - 1])
        {
            currentLength++;
        }
        else
        {
            if (currentLength > longestSeriesLength)
            {
                longestSeriesLength = currentLength;
                longestSeriesRow = i;
            }
            currentLength = 1;
        }
    }

    if (currentLength > longestSeriesLength)
    {
        longestSeriesLength = currentLength;
        longestSeriesRow = i;
    }
}
Console.WriteLine($"Номер строки с самой длинной серией одинаковых элементов: {longestSeriesRow}");
