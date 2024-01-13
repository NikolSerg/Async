async Task AsyncCounter(int t, string id)
{
    await Task.Run(() =>
    {
        Thread.CurrentThread.Name = "Поток " + Thread.CurrentThread.ManagedThreadId.ToString();
        Thread.CurrentThread.IsBackground = false;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Итерация {i} в Задаче: {Task.CurrentId}, Имя потока: {Thread.CurrentThread.Name}, Базовый поток: {id}");

            Task.Delay(t);
        }
    });
}
void Start(int max)
{
    for (int i = 0; i < max; i++)
    {
        Task task = AsyncCounter(new Random().Next(10, 50), Thread.CurrentThread.Name);
    }
}

Thread th1 = new Thread(() => Start(10));
th1.Name = "Первый";
Thread th2 = new Thread(() => Start(5));
th2.Name = "Второй";
th1.Start();
th2.Start();

//Console.ReadLine();

