using NUnit.Framework;
using System.Collections;
using StringListHandler;
using System;
using System.Linq;
using System.Collections.Generic;

namespace StringListHandler.Test
{
    [TestFixture]
    public class OrderingByTest
    {
        private string[] names = {
                "Sonia Maria Wood Dempster",
                "Laruen Ana Eagles Beneke",
                "Dorothy Rose Wong Dewitt",
                "Sandra Linda Dodge Holder"
            };

        [Test]
        public void SortedListContainsSameNumberOfItems()
        {
            IList sut = OrderingBy.Position(names, new int[] { 4, 2, 3, 1 });

            Assert.That(sut, Has.Exactly(names.Length).Items,
                "Result total items should be equals to the names lenght array");
        }

        [Test]
        [TestCase(new string[] {
            "Sonia Maria Wood Dempster",
            "Laruen Ana Eagles Beneke",
            "Dorothy Rose Wong Dewitt",
            "Sandra Linda Dodge Holder",
        },
            new int[] { 4, 2, 3, 1 },
            ExpectedResult = new string[] {
                "Sandra Linda Dodge Holder",
                "Laruen Ana Eagles Beneke",
                "Dorothy Rose Wong Dewitt",
                "Sonia Maria Wood Dempster",
             })]
        [TestCase(new string[] {
            "Sonia Maria Wood Dempster",
            "Laruen Ana Eagles Beneke",
            "Dorothy Rose Wong Dewitt",
            "Sandra Linda Dodge Holder",
        },
            new int[] { 4, 1, 2, 3 },
            ExpectedResult = new string[] {
                "Sandra Linda Dodge Holder",
                "Sonia Maria Wood Dempster",
            "Laruen Ana Eagles Beneke",
            "Dorothy Rose Wong Dewitt",
             })]
        [TestCase(new string[] {
            "Sonia Maria Wood Dempster",
            "Laruen Ana Eagles Beneke",
            "Dorothy Rose Wong Dewitt",
            "Sandra Linda Dodge Holder",
        },
            new int[] { 2, 4, 3, 1 },
            ExpectedResult = new string[] {
                "Laruen Ana Eagles Beneke",
                 "Sandra Linda Dodge Holder",
                  "Dorothy Rose Wong Dewitt",
                   "Sonia Maria Wood Dempster",
             })]
        public IList SortingIsWorking(IList<string> stringlist, IList<int> order)
        {
            return OrderingBy.Position(stringlist, order);
        }

        [Test]
        public void StringArrayHasMoreElementsThanOrderArray()
        {
            Assert.That(() => OrderingBy.Position(names, new int[] { 2, 3, 1 }), Throws.TypeOf<ArgumentException>()
                             .With
                             .Property("Message")
                             .EqualTo("The string array has more elements than the order array."));
        }

        [Test]
        public void StringArrayHasLessElementsThanOrderArray()
        {
            Assert.That(() => OrderingBy.Position(names.SkipLast(1).ToArray(), new int[] { 4, 2, 3, 1 }), Throws.TypeOf<ArgumentException>()
                             .With
                             .Property("Message")
                             .EqualTo("The string array has fewer elements than the order array."));
        }

        [Test]
        public void SmallestValueCannotBeZeroOrLess()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => OrderingBy.Position(names, new int[] { 4, 0, 3, 1 }), Throws.TypeOf<ArgumentException>()
                             .With
                             .Property("Message")
                             .EqualTo("The smallest value cannot be equal to or less than zero."));

                Assert.That(() => OrderingBy.Position(names, new int[] { 4, 2, -3, 1 }), Throws.TypeOf<ArgumentException>()
                             .With
                             .Property("Message")
                             .EqualTo("The smallest value cannot be equal to or less than zero."));
            });
        }

        [Test]
        public void NotAllowNulls()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => OrderingBy.Position(null, new int[] { 4, 2, 3, 1 }), Throws.TypeOf<ArgumentNullException>());
                Assert.That(() => OrderingBy.Position(names, null), Throws.TypeOf<ArgumentNullException>());
            });
        }
    }
}
