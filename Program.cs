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
    int lenght = 100;
    try
    {
        while(sumException++ < lenght)
        {
            try
            {
                //Console.WriteLine($"await Task.Run - {DateTime.Now}");
                //await Task.Run(() => { Calculate(lenght); });

                Console.WriteLine($"void Calculate - {DateTime.Now}");
                Calculate(lenght);


                Console.WriteLine($"await CalculateAsync - {DateTime.Now}");
                CalculateAsync(lenght);


    
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} - {sumException}");
            }
            Console.WriteLine($"end - {DateTime.Now}");

        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"await CalculateAsync  error {e.Message} ");
    }


    return sumException;

}

void Calculate(int a)
{
    Console.WriteLine($"Calculate sync");
    restClient = new RestClient("https://localhost:7231/connect/get-app/123");
    RestRequest restRequest = new RestRequest();
    restClient.Get(restRequest);
}

async void CalculateAsync(int a)
{
    Console.WriteLine($"Calculate AAAsync");

    restClient = new RestClient("https://localhost:7231/connect/get-app/123");
    RestRequest restRequest = new RestRequest();
    await restClient.GetAsync(restRequest);
}