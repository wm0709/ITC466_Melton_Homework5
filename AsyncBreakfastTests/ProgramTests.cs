using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncBreakfast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncBreakfast.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        Program program = new Program();

        [TestMethod()]
        public async Task MakeToastWithButterAndJamAsyncTestMadeToast()
        {
            var toastTask = program.MakeToastWithButterAndJamAsyncMock(1);
            await Task.WhenAll(toastTask);
            Assert.IsTrue(program.madeToast);
        }

        [TestMethod()]
        public async Task MakeToastWithButterAndJamAsyncTestAppliedButter()
        {
            var toastTask = program.MakeToastWithButterAndJamAsyncMock(1);
            await Task.WhenAll(toastTask);
            Assert.IsTrue(program.appliedButter);
        }

        [TestMethod()]
        public async Task MakeToastWithButterAndJamAsyncTestAppliedJam()
        {
            var toastTask = program.MakeToastWithButterAndJamAsyncMock(1);
            await Task.WhenAll(toastTask);
            Assert.IsTrue(program.appliedJam);
        }

        [TestMethod()]
        public void PourOJTest()
        {
            program.PourOJMock();
            Assert.IsTrue(program.pouredOJ);
        }

        [TestMethod()]
        public async Task FryBaconAsyncTest()
        {
            var baconTask = program.FryBaconAsyncMock(1);
            await Task.WhenAll(baconTask);
            Assert.IsTrue(program.baconDone);
        }

        [TestMethod()]
        public async Task FryEggsAsyncTest()
        {
            var eggTask = program.FryEggsAsyncMock(1);
            await Task.WhenAll(eggTask);
            Assert.IsTrue(program.eggsDone);
        }

        [TestMethod()]
        public void PourCoffeeMockTest()
        {
            program.PourCoffeeMock();
            Assert.IsTrue(program.pouredCoffee);
        }
    }
}