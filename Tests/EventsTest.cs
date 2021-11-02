using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

namespace Tests
{
    public class EventsTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CreateInstanceObjectEventsTest()
        {
            var objEvent = ScriptableObject.CreateInstance<ObjectEventsClass>();
            Vector3 pass = Vector3.back;
            objEvent.OnEvent += vector3 =>
            {
                Assert.AreEqual(Vector3.back, vector3);
            };
            objEvent.OnEvent.Invoke(pass);
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void CreateInstanceTwoStateEventsTest()
        {
            var objEvent = ScriptableObject.CreateInstance<TwoStateEventsClass>();
            Vector3 pass = Vector3.back;
            objEvent.OnPrimaryEvent += vector3 =>
            {
                Assert.AreEqual(Vector3.back, vector3);
            };
            objEvent.OnPrimaryEvent.Invoke(pass);
            pass = Vector3.down;
            objEvent.OnSecondaryEvent += vector3 =>
            {
                Assert.AreEqual(Vector3.down, vector3);
            };
            objEvent.OnSecondaryEvent.Invoke(pass);
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void CreateInstanceComponentEventsTest()
        {
            var compEvent = ScriptableObject.CreateInstance<ComponentEventClass>();
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            compEvent.OnEvent += tr =>
            {
                Assert.AreEqual(Vector3.forward, tr.forward);
            };
            compEvent.GetComponent(gameObject);
        }
        
/*
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EventsTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
*/
    }
}
