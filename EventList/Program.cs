using System.Threading.Channels;
using System.Collections.Generic;

class SurName
{ 
    private List<string> Surnames;

    public event Action<List<string>> SortedSur;

    public SurName(List<string> iniSur)
    {
        Surnames = new List<string>(iniSur);
    }


    public void Sort(bool asc) 
    {
        if (asc)
        {
            Surnames.Sort();
        }
        else 
        {
            Surnames.Sort((x, y) => string.Compare(y, x));
        }
        OnSortedSur();


    }
    protected virtual void OnSortedSur()
    {
        SortedSur?.Invoke(Surnames);
    }
    
}

class Programm
{
    static void Main(){

        var iniSur = new List<string>
        {
            "Лачев",
            "Сафонов",
            "Дачкин",
            "Белосевич",
            "Пегов"
        };
        var surnamesList = new SurName(iniSur);
        surnamesList.SortedSur += (Surnames) =>
        {
            Console.WriteLine("СПИСОК ОТСОРТИРОВАН!!!!!!");
            foreach (var surname in Surnames)
            {
                Console.WriteLine(surname);
            }
        };
        Console.WriteLine("Введите 1 для сортировки от начала или 2 для сортировки с конца");
        string input = Console.ReadLine();
        if (input == "1")
        {
            surnamesList.Sort(true);
        }
        else if (input == "2")
        {
            surnamesList.Sort(false);
        }
        else 
        {
            Console.WriteLine("Ошибка,введено некорекктное значение");
        }
            
     
    }
}