namespace APICatalogo.Service;

public class MyService : IMyService
{
    public string Saudation(string name)
    {
        return $"Bem vindo, {name} \n\n {DateTime.UtcNow}";
    }
}