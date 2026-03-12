# 제네릭 큐 (GenericQueue)

고정 크기 배열을 기반으로 동작하는 제네릭 큐 클래스를 만드세요.

### 요구사항

**`SimpleQueue<T>` 클래스**

- 생성자에서 용량(capacity)을 지정받아 고정 크기 배열 생성
- `Enqueue(T item)`: 큐에 아이템 추가. 가득 차면 `"큐가 가득 찼습니다."` 출력 후 무시
- `Dequeue()`: 가장 먼저 넣은 아이템을 제거하고 반환. 비어있으면 `"큐가 비어있습니다."` 출력 후 `default(T)` 반환
- `Peek()`: 가장 먼저 넣은 아이템을 반환 (제거하지 않음). 비어있으면 `"큐가 비어있습니다."` 출력 후 `default(T)` 반환
- `Count` 속성: 현재 저장된 아이템 수 (읽기 전용)
- `IsFull` 속성: 큐가 가득 찼는지 여부 (읽기 전용)
- `IsEmpty` 속성: 큐가 비어있는지 여부 (읽기 전용)

**테스트**

1. 용량 3인 `SimpleQueue<int>` 생성 후 Enqueue/Dequeue/Peek 테스트 (오버플로우 포함)
2. 용량 2인 `SimpleQueue<string>` 생성 후 Enqueue/Dequeue 테스트 (언더플로우 포함)

## 예상 실행 결과

```
=== int 큐 (용량: 3) ===
Enqueue: 10, 20, 30
Count: 3, IsFull: True
큐가 가득 찼습니다.
Peek: 10
Dequeue: 10
Dequeue: 20
Count: 1, IsEmpty: False

=== string 큐 (용량: 2) ===
Enqueue: Hello, World
Dequeue: Hello
Dequeue: World
큐가 비어있습니다.
Dequeue:
IsEmpty: True
```
