namespace PcConfigurator.Services.Factories;

public interface IFactory<T>
{
    T? GetByName(string name);
}