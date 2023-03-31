// See https://aka.ms/new-console-template for more information

using RestSharp;
using System.Runtime.CompilerServices;

var returnInit = await Init();
Console.WriteLine($"exceptions - {returnInit}");
RestClient restClient;

async Task<int> Init()
{
    Console.WriteLine($"start - {DateTime.Now}");
    int sumException = 0;
    int lenght = 100000;
    DateTime init = DateTime.Now;
    try
    {
        Console.WriteLine($"TEST 1 Async x Sync - {DateTime.Now} --- TOTAL = {lenght}");
        init = DateTime.Now;
        while (sumException++ < lenght)
        {
            try
            {
                //Console.WriteLine($"await Task.Run - {DateTime.Now}");
                //await Task.Run(() => { Calculate(lenght); });

                //test-1
                //Async => Void
                CalculateAsync(lenght);
                Calculate(lenght);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {sumException}");
            }         
           
        }
        Console.WriteLine($"end - {(DateTime.Now - init).TotalMilliseconds}");
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"TEST 2 Sync x Async - {DateTime.Now}");
        sumException = 0;
        init = DateTime.Now;
        while (sumException++ < lenght)
        {
            try
            {
                //Console.WriteLine($"await Task.Run - {DateTime.Now}");
                //await Task.Run(() => { Calculate(lenght); });

                //test-2
                //Void => Async
                Calculate(lenght);
                CalculateAsync(lenght);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {sumException}");
            }
        }
        Console.WriteLine($"end - {(DateTime.Now - init).TotalMilliseconds}");
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"TEST 3 Async - {DateTime.Now}");
        sumException = 0;
        init = DateTime.Now;
        while (sumException++ < lenght)
        {
            try
            {
                //Console.WriteLine($"await Task.Run - {DateTime.Now}");
                //await Task.Run(() => { Calculate(lenght); });

                //test-3
                //Async => Async
                CalculateAsync(lenght);
                CalculateAsync(lenght);

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {sumException}");
            }

        }
        Console.WriteLine($"end - {(DateTime.Now - init).TotalMilliseconds}");
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"-----------------------");
        Console.WriteLine($"TEST 4 Sync - {DateTime.Now}");
        
        sumException = 0;     
        init = DateTime.Now;
        while (sumException++ < lenght)
        {


            try
            {
                //Console.WriteLine($"await Task.Run - {DateTime.Now}");
                //await Task.Run(() => { Calculate(lenght); });

                //test-4
                //Void => Void
                Calculate(lenght);
                Calculate(lenght);

            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {sumException}");
            }
        }

        Console.WriteLine($"end - {(DateTime.Now - init).TotalMilliseconds}");

    }
    catch (Exception e)
    {
        Console.WriteLine($"await CalculateAsync  error {e.Message} ");
    }


    return sumException;

}

void Calculate(int a)
{
    if (a < 10000) Calculate(a*a);
}

async void CalculateAsync(int a)
{
    if (a < 10000) CalculateAsync(a*a);
}

async void CalculateAsync2(int a)
{
    if (a < 10000) Calculate(a*a);
}