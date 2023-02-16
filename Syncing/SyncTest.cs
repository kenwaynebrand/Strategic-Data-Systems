using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace DeveloperSample.Syncing
{
    public class SyncTest
    {
        [Fact]
        public void CanInitializeCollection()
        {
            var debug = new SyncDebug();
            var items = new List<string> { "one", "two" };
            var result = debug.InitializeList(items);
            Assert.Equal(items.Count, result.Count);
        }

        [Fact]
        public void ItemsOnlyInitializeOnce()
        {
            var debug = new SyncDebug();
            var count = 0;
            int thread = 0;
            var dictionary = debug.InitializeDictionary(i =>
            {
                thread++;
                var m = thread % 3;
                if (m == 0)
                {
                    Interlocked.Increment(ref count);
                    thread = 0;
                }

                Thread.Sleep(1);

                return i.ToString();
            });

            Assert.Equal(100, count);
            Assert.Equal(100, dictionary.Count);
        }
    }
}