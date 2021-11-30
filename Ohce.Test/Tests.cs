using System;
using NUnit.Framework;

namespace Ohce.Test
{
    public class Tests
    {

        [Test]
        public void GetGreetings_22h_ReturnsBuenasNoche()
        {
            // Given
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(20,0)));
            
            // When
            string result = ohce.GetGreeting("John Shepard");
            
            // Then
            Assert.AreEqual("¡Buenas noches John Shepard!", result);
        }
        
        [Test]
        public void GetGreetings_9h_ReturnsBuenasDias()
        {
            // Given
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(9,0)));
            
            // When
            string result = ohce.GetGreeting("John Shepard");
            
            // Then
            Assert.AreEqual("¡Buenos días John Shepard!", result);
        }
    }
}

