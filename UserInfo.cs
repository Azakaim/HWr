using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



struct Worker
{
    
    private static int Id;

    public static int PropId
    {
        get { return Id; }
        private set { Id = value; }
    }

    public static void OutputInfoUser(string path = @"homework_7.txt")
    {
        string[] UserInfoId;
        int CountLines = File.ReadAllLines(path).Length;
        string[] phrase = { "Информация об Id", "Ф.И.О.", "Возраст",
                            "Рост","Дaта рождения","Место рождения" 
                          };
        Console.WriteLine("Введите Id(1-10) сотрудника");
        do
        {
            string _Id_ = Console.ReadLine();
            int.TryParse(_Id_, out Id);
            if (Id <= CountLines && Id != 0) break;
            else { Console.WriteLine("Попробуйте еще раз!"); }
        } while (Id == 0 || Id > CountLines);
        var sr = new StreamReader(path);
        do
        {
            UserInfoId = sr.ReadLine().Split("#"); ;

        } while (Convert.ToInt32(UserInfoId[0]) != Id);
        //Вывод информации о работнике
        for (int i = 0, y = 1; i < phrase.Length; i++,y++)
        {
            if (i == 0) { Console.WriteLine($"{phrase[i]}:{UserInfoId[i]}"); }
            else { Console.WriteLine($"{phrase[i]}:{UserInfoId[y]}"); };
        }

    }
    
    public static void RemoveUser(string path = @"homework_7.txt")
    {

        int NumId = 0;
        var arr = File.ReadAllLines(path);

        Console.WriteLine($"Введите Id работника для его удаления из БД:");
        do
        {
            string str = Console.ReadLine(); 
            int.TryParse(str, out NumId);

            if (NumId == 0 || NumId > File.ReadAllLines(path).Length) 
            {
                Console.WriteLine($"Существуют Id:");
                foreach (var item in arr)
                {
                    Console.Write(" " + item.Split("#")[0]);
                    Console.WriteLine(Environment.NewLine + $"Введите Id работника из существующих:");
                }

            }

        } while (NumId == 0 || NumId > File.ReadAllLines(path).Length);

        List<string> NewArr = new();

        foreach (var item in arr)
        {
            if (item.Split("#")[0] == NumId.ToString())
            {
                arr.SetValue("",Convert.ToUInt32(item.Split("#")[0]) - 1);
                foreach (var item1 in arr)
                {
                    if (item1 != "") NewArr.Add(item1);
                }
                break;
            }
        }
        File.Delete(path);
        File.WriteAllLines(path,NewArr);
    }
    public static void EditInfoUser(string path = @"homework_7.txt")
    {
        int NumId = 0, i = 0, y = 0;
        var arr = File.ReadAllLines(path);
        int count = File.ReadAllLines(path).Length;
        int[] val = new int[count];
        string[] arr1 = new string[count];
        //определяем  Id
        foreach (var item in arr) { val[i] = Convert.ToInt32(item.Split("#")[0]); i++; }

        Console.WriteLine($"Введите Id работника для изменения информации:");
        do
        {
            string str = Console.ReadLine();
            int.TryParse(str, out NumId);
            
            if (NumId == 0 || NumId > val.Max() || NumId < val.Min())
            {
                Console.WriteLine($"Существуют Id:");
                foreach (var item in arr){Console.Write(" " + item.Split("#")[0]);}
                Console.WriteLine(Environment.NewLine + $"Введите Id работника из существующих:");
            }

            

        } while (NumId == 0 || NumId > val.Max() || NumId < val.Min());

        foreach (var item in arr)
        {
            if (item.Split("#")[0] == NumId.ToString())
            {
                arr.SetValue($"{CreatUser(setvalue: NumId)}", y);break;
            }
            //номер строки массива 
            y++;
        }
        File.Delete(path);
        File.WriteAllLines(path, arr);
    }
    public static string CreatUser(string path = @"homework_7.txt",int setvalue = 0)
    {
        string WorkerInfo = String.Empty;
        string answer;
        int ColLines = 0;
        string[] phrases =
        {
                "Введите Ф.И.О. работника: ", "Введите возраст работника: ","Введите рост работника: ",
                "Введите дату рождения работника: ","Введите место рождения работника: ",
        };
        if (!File.Exists(path))
        {
            using (var sw = new StreamWriter(path))
            {

                for (int i = 0; i < phrases.Length; i++)
                {
                    if (i == 0)
                    {
                        try
                        {
                            ColLines = File.ReadAllLines(path).Length;
                        }
                        catch (Exception) { };
                        Console.WriteLine(phrases[i]);
                        answer = Console.ReadLine();
                        // это Id - порядковый номер работника
                        WorkerInfo = $"{Convert.ToString(ColLines + 1)}#{DateTime.Now}#{answer}";

                    }
                    else
                    {
                        Console.WriteLine(phrases[i]);
                        answer = Console.ReadLine();
                        WorkerInfo += "#" + answer;
                    }
                }
                sw.WriteLine("\r" + WorkerInfo);
            }
        }
        else
        {
            for (int i = 0; i < phrases.Length; i++)
            {
                if (i == 0)
                {
                    string[] str = File.ReadAllLines(path);

                    #region проверка точно ли файл пуст
                    var Byte = File.ReadAllBytes(path);
                    bool flag = false;
                    
                    foreach (var item in str)
                    {
                        flag = String.IsNullOrEmpty(item);
                    }
                    #endregion

                    if (flag && Byte.Length != 0) { ColLines = 0;File.Delete(path);/*сносим файл*/ }
                    //это Id - порядковый номер работника
                    else { ColLines = File.ReadAllLines(path).Length; }
                    Console.WriteLine(phrases[i]);
                    answer = Console.ReadLine();
                    if (setvalue == 0) WorkerInfo = $"{Convert.ToString(ColLines + 1)}#{DateTime.Now}#{answer}";
                    else { WorkerInfo = $"{setvalue}#{DateTime.Now}#{answer}"; }

                }
                else
                {
                    Console.WriteLine(phrases[i]);
                    answer = Console.ReadLine();
                    WorkerInfo += $"#{answer}";
                }
            }
            File.AppendAllText(path,Environment.NewLine + WorkerInfo);
        }
        return WorkerInfo;
    }
   
}
struct Cho
{
    public static void ice()
    {
        string CreatUs = "1 - Создание записи о работнике";
        string OutputInfoUs = "\n2 - Просмотр записи о работнике";
        string RemoveUs = "\n3 - Удаление записи о работнике";
        string EditInfoUs = "\n4 - Редактирование записи о работнике";
        Console.WriteLine("{0}{1}{2}{3}", CreatUs, OutputInfoUs, RemoveUs, EditInfoUs);
        bool flag;
        do
        {
            string KeyNum = Console.ReadLine();
            flag = int.TryParse(KeyNum, out int switch_on);
            switch (switch_on)
            {
                case 1: Worker.CreatUser(); break;
                case 2: Worker.OutputInfoUser(); break;
                case 3: Worker.RemoveUser(); break;
                case 4: Worker.EditInfoUser(); break;
                default: flag = false; Console.WriteLine("Попробуйте еще раз!"); break;
            }
        } while (!flag);

    }
}