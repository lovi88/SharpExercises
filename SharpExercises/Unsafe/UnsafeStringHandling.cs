using System;

namespace SharpExercises.Unsafe
{
    class UnsafeStringHandling
    {

        public static void PrintStringAndGarbage()
        {
            const string str = "my string";

            unsafe
            {
                fixed (char* p = str)
                {
                    for (int i = 0; i < str.Length + 5; i++)
                    {
                        Console.Write((p + i)->ToString());
                    }
                    Console.WriteLine();
                }
            }
        }

    }

}
