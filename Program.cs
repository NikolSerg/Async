async Task AsyncCounter(int t, int i)
{
    await Task.Run(() =>
    {
        Thread.CurrentThread.Name = "Поток " + i;
        Thread.CurrentThread.IsBackground = false;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Итерация {i} в Задаче: {Task.CurrentId}, Имя потока: {Thread.CurrentThread.Name}");

            Task.Delay(t).Wait();
        }
    });
}
void Start()
{
    for (int i = 0; i < 10; i++)
    {
        AsyncCounter(new Random().Next(10, 50), i);
    }
}

Start();

//Console.ReadLine();

