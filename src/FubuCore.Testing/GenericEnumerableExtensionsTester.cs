using System.Collections.Generic;
using NUnit.Framework;

namespace FubuCore.Testing
{
    [TestFixture]
    public class GenericEnumerableExtensionsTester
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
        }

        #endregion

        [Test]
        public void Fill_a_value_into_a_list()
        {
            var list = new List<string>();

            list.Fill("a");

            list.Count.ShouldEqual(1);
            list.Contains("a").ShouldBeTrue();

            // don't add it if it already exists
            list.Fill("a");
            list.Count.ShouldEqual(1);
        }

        [Test]
        public void FirstValue()
        {
            var objects = new[]
            {
                new TestObject(), new TestObject(),
                new TestObject()
            };
            objects.FirstValue(x => x.Child).ShouldBeNull();

            var theChild = new TestObject();
            objects[1].Child = theChild;
            objects[2].Child = new TestObject();

            objects.FirstValue(x => x.Child).ShouldBeTheSameAs(theChild);
        }

        [Test]
        public void join()
        {
            var list = new List<string>(new[] {"a", "b", "c"});
            list.Join(", ").ShouldEqual("a, b, c");
        }

        [Test]
        public void add_many_and_range()
        {
            var list = new List<string>();
            list.AddMany("a", "b", "c");

            list.ShouldHaveTheSameElementsAs("a", "b", "c");
        }
    }
}