using System.Collections.Generic;

namespace ToonShooterPrototype.Utilities.Extensions
{
    public static class SequenceExtensions
    {
        public static int FirstIndex<T>(this ICollection<T> source) => default;
        public static int LastIndex<T>(this ICollection<T> source) => source.Count - 1;

        public static bool IsInIndexRange<T>(this ICollection<T> source, int index) =>
            index >= source.FirstIndex() && index <= source.LastIndex();
    }
}