using System.Collections.Generic;

namespace Toolbox
{
    public interface ITestPair<T, TKey>
    {
        public TKey Input { get; set; }
        public TKey ExpectedOutput { get; set; }

        public IEnumerable<T> ParseFromStringPair(IEnumerable<StringPair> input);
    }
}
