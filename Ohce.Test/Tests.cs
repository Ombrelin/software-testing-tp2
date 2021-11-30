using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ohce.Test
{
    public class Tests
    {

        [Test]
        public void GetGreetings_Between20hAnd00h_ReturnsBuenasNoche()
        {
            for (int hours = 20; hours < 24; ++hours)
            {
                for (int minutes = 0; minutes < 60; ++minutes)
                {
                    // Given
                    var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(hours,minutes)), new FakeIO());
            
                    // When
                    string result = ohce.GetGreeting("John Shepard");
            
                    // Then
                    Assert.AreEqual("¡Buenas noches John Shepard!", result);
                }
            }
        }
        
        [Test]
        public void GetGreetings_Between00hAnd6h_ReturnsBuenasNoche()
        {
            for (int hours = 0; hours < 6; ++hours)
            {
                for (int minutes = 0; minutes < 60; ++minutes)
                {
                    // Given
                    var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(hours,minutes)), new FakeIO());
            
                    // When
                    string result = ohce.GetGreeting("John Shepard");
            
                    // Then
                    Assert.AreEqual("¡Buenas noches John Shepard!", result);
                }
            }
        }
        
        [Test]
        public void GetGreetings_Between6And12_ReturnsBuenasDias()
        {
            for (int hours = 6; hours < 12; ++hours)
            {
                for (int minutes = 0; minutes < 60; ++minutes)
                {
                    // Given
                    var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(hours,minutes)), new FakeIO());
            
                    // When
                    string result = ohce.GetGreeting("John Shepard");
            
                    // Then
                    Assert.AreEqual("¡Buenos días John Shepard!", result);
                }
            }
        }
        
        [Test]
        public void GetGreetings_Between12And20_ReturnsBuenasTardes()
        {
            for (int hours = 12; hours < 20; ++hours)
            {
                for (int minutes = 0; minutes < 60; ++minutes)
                {
                    // Given
                    var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(hours,minutes)), new FakeIO());
            
                    // When
                    string result = ohce.GetGreeting("John Shepard");
            
                    // Then
                    Assert.AreEqual("¡Buenas tardes John Shepard!", result);
                }
            }
        }

        [Test]
        [TestCase("kayak")]
        [TestCase("xanax")]
        [TestCase("noon")]
        [TestCase("mom")]
        public void IsPalindrome_GivenPalindrome_ReturnsTrue(string palindrome)
        {
            // Given
            var ohce = new Ohce(null, new FakeIO());
            
            // When
            bool isPalindrome = ohce.IsPalindrome(palindrome);
            
            // Then
            Assert.True(isPalindrome);
        }
        
        [Test]
        [TestCase("raDar")]
        [TestCase("Rotor")]
        [TestCase("cIvic")]
        [TestCase("levEl")]
        public void IsPalindrome_GivenPalindromeWithInconsistentCasing_ReturnsTrue(string palindrome)
        {
            // Given
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0,0)), new FakeIO());
            
            // When
            bool isPalindrome = ohce.IsPalindrome(palindrome);
            
            // Then
            Assert.True(isPalindrome);
        }
        
        [Test]
        [TestCase("citadel")]
        [TestCase("calibrations")]
        [TestCase("airlock")]
        public void IsPalindrome_GivenNotPalindrome_ReturnsFalse(string notPalindrome)
        {
            // Given
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0,0)), new FakeIO());
            
            // When
            bool isPalindrome = ohce.IsPalindrome(notPalindrome);
            
            // Then
            Assert.False(isPalindrome);
        }
        
        [Test]
        [TestCase("citadel", "ledatic")]
        [TestCase("calibrations","snoitarbilac")]
        [TestCase("airlock","kcolria")]
        public void ReverseWord_ReturnsReversedWord(string word, string reversedWord)
        {
            // Given
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0,0)), new FakeIO());
            
            // When
            string result = ohce.ReverseWord(word);
            
            // Then
            Assert.AreEqual(reversedWord, result);
        }

        [Test]
        public async Task Run_OutPutsGreetingStopIfStop()
        {
            // Given
            var inputs = new Queue<string>();
            inputs.Enqueue("Stop!");
            var fakeIO = new FakeIO(inputs);
            
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0, 0)), fakeIO);
            
            // When
            await ohce.Run("John Shepard");
            
            // Then
            Assert.AreEqual("¡Buenas noches John Shepard!",fakeIO.Output[0]);
            Assert.AreEqual("Adios John Shepard",fakeIO.Output[1]);
            Assert.True(fakeIO.HandleExitCalled);
        }
        
        [Test]
        public async Task Run_OutPutsTakeInputAndOutputsPalindrome()
        {
            // Given
            var inputs = new Queue<string>();
            inputs.Enqueue("allo");
            inputs.Enqueue("Stop!");
            var fakeIO = new FakeIO(inputs);
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0, 0)), fakeIO);
            
            // When
            await ohce.Run("John Shepard");
            
            // Then
            Assert.AreEqual("olla",fakeIO.Output[1]);
        }
        
        [Test]
        public async Task Run_OutPutsTakeInputAndOutputsPalindromeMultipleTimes()
        {
            // Given
            var inputs = new Queue<string>();
            inputs.Enqueue("allo");
            inputs.Enqueue("hello");
            inputs.Enqueue("car");
            inputs.Enqueue("Stop!");
            var fakeIO = new FakeIO(inputs);
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0, 0)), fakeIO);
            
            // When
            await ohce.Run("John Shepard");
            
            // Then
            Assert.AreEqual("olla",fakeIO.Output[1]);
            Assert.AreEqual("olleh",fakeIO.Output[2]);
            Assert.AreEqual("rac",fakeIO.Output[3]);
        }
        
        [Test]
        public async Task Run_OutPutsMessageIfPalindrome()
        {
            // Given
            var inputs = new Queue<string>();
            inputs.Enqueue("kayak");
            inputs.Enqueue("Stop!");
            var fakeIO = new FakeIO(inputs);
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(0, 0)), fakeIO);
            
            // When
            await ohce.Run("John Shepard");
            
            // Then
            Assert.AreEqual("kayak",fakeIO.Output[1]);
            Assert.AreEqual("¡Bonita palabra!",fakeIO.Output[2]);
        }
    }
}

