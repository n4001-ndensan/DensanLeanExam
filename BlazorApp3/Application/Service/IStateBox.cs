namespace BlazorApp3.Application.Service;

public interface IStateBox<T>
{
    T? State { get; set; }
    bool HasState { get; }
}
