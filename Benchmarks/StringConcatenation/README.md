# Comparing the performance of different string concatenation methods in C#

These benchmarks compare different approaches to string concatenation in C#.
Sometimes, it is claimed that `string.format` is more efficient than simple concatenation via the addition operator.
These benchmarks show that this is not the case: `string.format` takes significantly longer to run.
This makes sense when you consider that the format string has to be parsed first before any concatenation can occur.

## Exemplary result

```
BenchmarkDotNet=v0.13.5, OS=arch 
Intel Core i5-8350U CPU 1.70GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 7.0.2 (7.0.223.10501), X64 RyuJIT AVX2 DEBUG
  DefaultJob : .NET 7.0.2 (7.0.223.10501), X64 RyuJIT AVX2


                             Method |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
----------------------------------- |------------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
   StringConcatenationWithConstants |   0.7657 ns | 0.1093 ns | 0.1023 ns | 0.009 |    0.00 |      - |         - |        0.00 |
   StringConcatenationWithInterning | 145.4638 ns | 1.8882 ns | 1.5767 ns | 1.757 |    0.10 | 0.0153 |      48 B |        1.00 |
 StringConcatenationViaPlusOperator |  25.6463 ns | 0.4961 ns | 0.5514 ns | 0.308 |    0.02 | 0.0153 |      48 B |        1.00 |
                StringInterpolation |  25.3975 ns | 0.5901 ns | 0.7673 ns | 0.304 |    0.02 | 0.0153 |      48 B |        1.00 |
             StringConcatMethodCall |  25.5779 ns | 0.5973 ns | 0.4988 ns | 0.309 |    0.02 | 0.0153 |      48 B |        1.00 |
             StringFormatMethodCall |  82.4173 ns | 1.7347 ns | 3.9507 ns | 1.000 |    0.00 | 0.0153 |      48 B |        1.00 |
```