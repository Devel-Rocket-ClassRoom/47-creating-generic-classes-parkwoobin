using System;
using System.Collections.Generic;

// README.md를 읽고 아래에 코드를 작성하세요.



Console.WriteLine($"=== 총알 발사 ===");

ObjectPool<Bullet> bulletPool = new ObjectPool<Bullet>(3);
Bullet bullet1 = bulletPool.Get();
bullet1.X = 10;
bullet1.Y = 20;
Console.WriteLine($"총알 발사! 위치: ({bullet1.X}, {bullet1.Y})");
Bullet bullet2 = bulletPool.Get();
bullet2.X = 30;
bullet2.Y = 40;
Console.WriteLine($"총알 발사! 위치: ({bullet2.X}, {bullet2.Y})");
Bullet bullet3 = bulletPool.Get();
bullet3.X = 50;
bullet3.Y = 60;
Console.WriteLine($"총알 발사! 위치: ({bullet3.X}, {bullet3.Y})");
Console.WriteLine($"활성: {bulletPool.ActiveCount}, 비활성: {bulletPool.AvailableCount}");

Console.WriteLine($"\n=== 풀 초과 시도 ===");
try
{
    Bullet bullet4 = bulletPool.Get();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine($"\n=== 반납 후 재사용 ===");
bulletPool.Return(bullet1);
Console.WriteLine($"총알 반납됨");
Console.WriteLine($"활성: {bulletPool.ActiveCount}, 비활성: {bulletPool.AvailableCount}");
Bullet bullet5 = bulletPool.Get();
bullet5.X = 100;
bullet5.Y = 200;
Console.WriteLine($"총알 발사! 위치: ({bullet5.X}, {bullet5.Y})");
Console.WriteLine($"활성: {bulletPool.ActiveCount}, 비활성: {bulletPool.AvailableCount}");





public interface IPoolable
{
    void Reset();
}

class Bullet : IPoolable
{
    public int X { get; set; }
    public int Y { get; set; }

    public Bullet()
    {
        Reset();
    }

    public void Reset()
    {
        X = 0;
        Y = 0;
    }
}


public class ObjectPool<T> where T : class, IPoolable, new()    // T는 참조 형식, 인터페이스 상속, 매개변수 없는 생성자
{
    private List<T> _available = new List<T>(); // 비활성(사용 가능) 오브젝트 목록
    private List<T> _active = new List<T>();    // 활성(사용 중) 오브젝트 목록
    private int maxSize;

    public int ActiveCount => _active.Count;
    public int AvailableCount => _available.Count;

    public ObjectPool(int maxSize)
    {
        this.maxSize = maxSize;
    }

    public T Get()
    {
        if (_available.Count > 0)
        {
            T obj = _available[0];
            _available.RemoveAt(0);
            _active.Add(obj);
            return obj;
        }
        if (_active.Count < maxSize)
        {
            T obj = new T();
            _active.Add(obj);
            return obj;
        }
        throw new InvalidOperationException("풀이 가득 찼습니다!");
    }

    public void Return(T item)
    {
        item.Reset();
        _active.Remove(item);
        _available.Add(item);
    }
}