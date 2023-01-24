// Задача:
// написать программу, которая из имеющегося массива строк 
// формирует массив из строк, длина которых меньше 
// либо равна 3 символам. 
// Первоначальный массив можно ввести с клавиатуры, 
// либо задать на старте выполнения алгоритма. 

// Примеры:
// ["hello","2","world",":-)",]->["2",":-)"]
// ["1234","1567","-2","computer scince"]->["-2"]
// ["Russia","Denmark","Kazan"]->[]


int SizeArray(string[] Array, int Element)
{
    string[] valid = new string[Array.Length];
    int count = 0;
    int validSize = Array.Length;
    for (int i = 0; i < Array.Length; i++)
    {
        string currentElement = Array[i];
        if (currentElement.Length > Element)
            count++;
    }
    validSize -= count;
    if (validSize == 0) validSize++;
    return validSize;
}


string[] ElementArray(string[] Array, int Element, int size)
{
    string[] result = new string[size];
    string element = string.Empty;
    int count = 0;
    for (int i = 0; i < result.Length; i++)
    {
        for (int j = count; j < Array.Length; j++)
        {
            string current = Array[j];
            if (current.Length <= Element)
            {
                element = current;
                count = j;
                break;
            }
            else count += j;
        }
        result[i] = element;
        count++;
    }
    return result;
}


void PrintArray(string[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write($"{array[i]},");
    }
    Console.Write($"{array[array.Length - 1]}]");
}


string[] UserArray()
{
    Console.Write("Укажите сколько строк Вы хотите ввести: ");
    int countString = Convert.ToInt32(Console.ReadLine());
    string[] newArray = new string[countString];
    if (countString <= 0) Console.WriteLine("Попробуйте снова, когда захотите что-нибудь ввести!");
    else
    {
        for (int i = 0; i < countString; i++)
        {
            Console.Write($"Введите строку №{i + 1}: ");
            newArray[i] += Console.ReadLine();
        }
    }
    return newArray;
}



int lengthString = 3;
string[] userArray = UserArray();
Console.WriteLine($"Ниже [введенные Вами строки] и [строки, длина которых меньше либо равна {lengthString} символам]:");
PrintArray(userArray);
Console.Write("->");
int validSizeArray = SizeArray(userArray, lengthString);
PrintArray(ElementArray(userArray, lengthString, validSizeArray));
