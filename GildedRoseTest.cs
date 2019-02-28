using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        // naming convention of each unit test is as follows:
        // ClassUnderTest_Method_Objective_Outcome

        #region Sellin unit tests        
        /// <summary>
        /// this unit test is for proving that the update of an item's Sellin property
        /// is properly updated at the end of the day, and done only once no matter
        /// how often the UpdateQuality() method is called
        /// </summary>
        [Test]
        public void GildedRose_UpdateQuality_SellinForAllItemsGetsUpdatedOnceDaily_success()
        {
            // in the production situation, the value for 
            // hasBeenRunToday would be taken from some persisted medium like 
            // a database. We use a hard coded value here just for the sake of 
            // test.
            bool hasBeenRunToday = false;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items, hasBeenRunToday);
            app.UpdateQuality();
            int expectedSellIn = 9; // this is with the assumption that decrementing of Sellin of the
            // item is by 1
            Assert.AreEqual(expectedSellIn, Items[0].SellIn);

            // run again on the same day
            // the item MUST not get incremented twice on the same day                                    
            app.UpdateQuality();
            expectedSellIn = 9; // this is with the assumption that decrementing of Sellin of the
            // item is by 1
            Assert.AreEqual(expectedSellIn, Items[0].SellIn);
        }
        #endregion Sellin unit tests

        #region Quality Unit Tests
        /// <summary>
        /// this unit test is for proving that the update of an item's Quality property
        /// is properly updated at the end of the day, and done only once no matter
        /// how often the UpdateQuality() method is called
        /// </summary>
        [Test]
        public void GildedRose_UpdateQuality_QualityForAllItemsGetsUpdatedOnceDaily_success()
        {            
            // in the production situation, the value for 
            // hasBeenRunToday would be taken from some persisted medium like 
            // a database. We use a hard coded value here just for the sake of 
            // test.
            bool hasBeenRunToday = false;
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items, hasBeenRunToday);
            app.UpdateQuality();
            int expectedQuality = 29; // this is with the assumption that decrementing of quality of the
            // item is by 1
            Assert.AreEqual(expectedQuality, Items[0].Quality);

            // run again on the same day
            // the item MUST not get incremented twice on the same day                                    
            app.UpdateQuality();            
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }
        #endregion Quality Unit Tests
    }
}
