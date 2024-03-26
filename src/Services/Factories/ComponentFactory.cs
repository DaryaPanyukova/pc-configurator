using PcConfigurator.Entities.Components;

namespace PcConfigurator.Services.Factories;

public class ComponentFactory<T> : IFactory<T>
    where T : IComponent
{
    private readonly List<T> _componentList;

    public ComponentFactory(IReadOnlyCollection<T> componentList)
    {
        _componentList = new List<T>(componentList);
    }

    public T? GetByName(string name)
    {
        return _componentList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}