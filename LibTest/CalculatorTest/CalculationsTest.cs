using LibUserCalculation;
namespace CalculationsTest
{
    [TestClass]
    public class CalculationsTests
    {
        private readonly Calculations calculations = new();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AvailablePeriods_NullStartTimes_ThrowsArgumentNullException()
        {
            calculations.AvailablePeriods(null, new int[] { 10 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AvailablePeriods_NullDurations_ThrowsArgumentNullException()
        {
            calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(10) }, null, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArrayMismatchException))]
        public void AvailablePeriods_ArrayLengthsMismatch_ThrowsArrayMismatchException()
        {
            calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(10) }, new int[] { 10, 20 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AvailablePeriods_ConsultationTimeNonPositive_ThrowsArgumentException()
        {
            calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(10) }, new int[] { 10 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AvailablePeriods_BeginWorkingTimeAfterEndWorkingTime_ThrowsArgumentOutOfRangeException()
        {
            calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(10) }, new int[] { 10 }, TimeSpan.FromHours(17), TimeSpan.FromHours(9), 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AvailablePeriods_StartTimeOutsideWorkingHours_ThrowsArgumentOutOfRangeException()
        {
            calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(8) }, new int[] { 10 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 30);
        }

        [TestMethod]
        public void AvailablePeriods_NoBusyPeriods_ReturnsFullDay()
        {
            var result = calculations.AvailablePeriods(new TimeSpan[] { }, new int[] { }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 60);
            var expected = new string[] { "09:00-10:00", "10:00-11:00", "11:00-12:00", "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00", "16:00-17:00" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AvailablePeriods_OneBusyPeriod_ReturnsAvailableSlots()
        {
            var result = calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(12) }, new int[] { 60 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 60);
            var expected = new string[] { "09:00-10:00", "10:00-11:00", "11:00-12:00", "13:00-14:00", "14:00-15:00", "15:00-16:00", "16:00-17:00" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AvailablePeriods_MultipleBusyPeriods_ReturnsAvailableSlots()
        {
            var result = calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(10), TimeSpan.FromHours(14) }, new int[] { 60, 60 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 60);
            var expected = new string[] { "09:00-10:00", "11:00-12:00", "12:00-13:00", "13:00-14:00", "15:00-16:00", "16:00-17:00" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AvailablePeriods_ExactFitWithinWorkingHours_ReturnsExactSlots()
        {
            var result = calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(9) }, new int[] { 480 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 60);
            var expected = new string[] { };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AvailablePeriods_NoConsultationTimeFit_ReturnsEmpty()
        {
            var result = calculations.AvailablePeriods(new TimeSpan[] { TimeSpan.FromHours(9), TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(12), TimeSpan.FromHours(13), TimeSpan.FromHours(14), TimeSpan.FromHours(15), TimeSpan.FromHours(16) }, new int[] { 60, 60, 60, 60, 60, 60, 60, 60 }, TimeSpan.FromHours(9), TimeSpan.FromHours(17), 60);
            var expected = new string[] { };
            CollectionAssert.AreEqual(expected, result);
        }
    }

}
