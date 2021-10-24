using FuckAutomapper.Runner.ObjTemplates;
using FuckAutomapper.TypeMap;

namespace FuckAutomapper
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleObjOrigin simpleObjOrigin = new SimpleObjOrigin();
            BigObjOrigin bigObjOrigin = new BigObjOrigin();
            TypeAdapter.RegisterAdapterMappingFunction<BigObjTarget, BigObjOrigin>(CopyProperties);
            SimpleObjTarget SimpleObjTarget = TypeAdapter.Adapt<SimpleObjTarget, SimpleObjOrigin>(simpleObjOrigin);
            BigObjTarget BigObjTarget = TypeAdapter.Adapt<BigObjTarget, BigObjOrigin>(bigObjOrigin);
            BigObjTarget BigObjTarget2 = TypeAdapter.Adapt(bigObjOrigin, CopyProperties);
        }

        public static BigObjTarget CopyProperties(BigObjOrigin obj)
        {
            return new BigObjTarget()
            {
                Str1 = obj.Str1,
                Str2 = obj.Str2,
                Str3 = obj.Str3,
                Str4 = obj.Str4,
                Str5 = obj.Str5,
                Str6 = obj.Str6,
                Str7 = obj.Str7,
                Str8 = obj.Str8,
                Str9 = obj.Str9,
                Str10 = obj.Str10,
                Str11 = obj.Str11,
                Str12 = obj.Str12,
                Str13 = obj.Str13,
                Str14 = obj.Str14,
                Str15 = obj.Str15,
                Str16 = obj.Str16,
                Str17 = obj.Str17,
                Str18 = obj.Str18,
                Str19 = obj.Str19,
                Str20 = obj.Str20,
                Str21 = obj.Str21,
                Str22 = obj.Str22,
                Str23 = obj.Str23,
                Str24 = obj.Str24,
                Str25 = obj.Str25,
                Int = obj.Int,
                Int2 = obj.Int2,
                Int3 = obj.Int3,
                Int4 = obj.Int4,
                Int5 = obj.Int5,
                Int6 = obj.Int6,
                Int7 = obj.Int7,
                Int8 = obj.Int8,
                Int9 = obj.Int9,
                Int10 = obj.Int10,
                Int11 = obj.Int11,
                Int12 = obj.Int12,
                Int13 = obj.Int13,
                Int14 = obj.Int14,
                Int15 = obj.Int15,
                Int16 = obj.Int16,
                Int17 = obj.Int17,
                Int18 = obj.Int18,
                Int19 = obj.Int19,
                Int20 = obj.Int20,
                Int21 = obj.Int21,
                Int22 = obj.Int22,
                Int23 = obj.Int23,
                Int24 = obj.Int24,
                Int25 = obj.Int25,
            };
        }
    }
}
