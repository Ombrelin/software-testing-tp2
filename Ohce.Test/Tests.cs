using System;
using NUnit.Framework;

namespace Ohce.Test
{
    public class Tests
    {

        [Test]
        public void GetGreetings_20h_ReturnsBuenasNoche()
        {
            // Given
            var ohce = new Ohce(new FakeCurrentTimeProvider(new TimeOnly(20,0)));
            
            // When
            string result = ohce.GetGreeting("John Shepard");
            
            // Then
            Assert.Equals("¡Buenas noches John Shepard!", result);
        }
    }
}

