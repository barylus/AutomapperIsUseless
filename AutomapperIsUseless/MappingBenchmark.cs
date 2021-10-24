using BenchmarkDotNet.Attributes;
using FuckAutomapper.Runner.ObjTemplates;
using FuckAutomapper.TypeMap;

namespace FuckAutomapper.Benchmarks
{

    [MemoryDiagnoser]
    public class MappingBenchmark
    {
        private static readonly SimpleObjOrigin simpleObjOrigin = new();
        private static readonly BigObjOrigin bigObjOrigin = new();


        [Benchmark]
        public SimpleObjTarget SimpleMapOperation() => TypeAdapter.Adapt<SimpleObjTarget, SimpleObjOrigin>(simpleObjOrigin);

        [Benchmark]
        public BigObjTarget BigObjMapOperation() => TypeAdapter.Adapt<BigObjTarget, BigObjOrigin>(bigObjOrigin);                 
    }
}
