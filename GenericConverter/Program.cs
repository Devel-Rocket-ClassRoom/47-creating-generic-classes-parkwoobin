using System;

// README.md를 읽고 아래에 코드를 작성하세요.

Converter<string, int> convert1 = new Converter<string, int>(s => s.Length);
string[] input1 = { "Hello", "World", "C#" };


Converter<int, string> convert2 = new Converter<int, string>(n => n.ToString());
int[] intValues = { 1, 2, 3 };


Converter<double, int> convert3 = new Converter<double, int>(d => (int)Math.Round(d));
double[] doubleValues = { 3.7, 1.2, 9.9 };

Console.WriteLine("=== 문자열 → 길이 변환 ===");
Console.WriteLine($"{input1[0]} -> {convert1.Convert(input1[0])}");
Console.WriteLine($"전체 변환: {string.Join(", ", convert1.ConvertAll(input1))}");

Console.WriteLine("\n=== 정수 → 문자열 변환 ===");
Console.WriteLine($"{intValues[0]} -> {convert2.Convert(intValues[0])}번");
Console.WriteLine($"전체 변환: {string.Join(", ", convert2.ConvertAll(intValues))}번");



Console.WriteLine("\n=== 실수 → 정수 변환 ===");
int[] convertedValues = new int[doubleValues.Length];   // 새로운 int배열 만들기 길이는 doubleValues만큼
for (int i = 0; i < doubleValues.Length; i++)   // doubleValues의 각 요소를 convert3을 이용하여 변환하여 convertedValues에 저장
{
    convertedValues[i] = (int)doubleValues[i];
}
Console.WriteLine($"{doubleValues[0]} -> {convert3.Convert(convertedValues[0])}");
Console.Write($"전체 변환:");

Console.WriteLine($" {string.Join(", ", convertedValues)}");

class Converter<TInput, TOutput>
{
    private Func<TInput, TOutput> _conversionFunction;

    public Converter(Func<TInput, TOutput> conversionFunction)
    {
        _conversionFunction = conversionFunction;
    }

    public TOutput Convert(TInput input)
    {
        return _conversionFunction(input);
    }

    public TOutput[] ConvertAll(TInput[] inputs)    // 배열을 입력받아 전체 변환하여 TOutput[]로 반환하는 메서드
    {
        TOutput[] outputs = new TOutput[inputs.Length];
        for (int i = 0; i < inputs.Length; i++)
        {
            outputs[i] = Convert(inputs[i]);
        }
        return outputs;
    }
}