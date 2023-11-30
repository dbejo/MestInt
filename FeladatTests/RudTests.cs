﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatTests
{
    public class RudTests
    {
        Rud rud1, rud2;
        [SetUp]
        public void Setup()
        {
            rud1 = new Rud(new Korong("piros", 2), new Korong("kek", 1));
            rud2 = new Rud();
        }

        [Test]
        public void RemoveKorongTest()
        {
            Assert.That(rud1.GetKorongok().Count(), Is.EqualTo(2));
            Korong removedKorong = rud1.RemoveTopKorong();
            Assert.That(removedKorong.GetSzin(), Is.EqualTo("kek"));
            Assert.That(removedKorong.GetAtmero(), Is.EqualTo(1));
            Assert.That(rud1.GetKorongok().Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddKorongAzonosAtmeroTest()
        {
            Assert.That(rud1.GetKorongok().Count(), Is.EqualTo(2));
            Assert.That(rud1.GetKorongok().Last().GetSzin(), Is.EqualTo("kek"));
            Assert.That(rud1.GetKorongok().Last().GetAtmero(), Is.EqualTo(1));
            bool isSucessful = rud1.AddKorong(new Korong("piros", 1));
            Assert.That(isSucessful, Is.True);
            Assert.That(rud1.GetKorongok().Count(), Is.EqualTo(3));
            Assert.That(rud1.GetKorongok().Last().GetSzin(), Is.EqualTo("piros"));
            Assert.That(rud1.GetKorongok().Last().GetAtmero(), Is.EqualTo(1));
        }

        [Test]
        public void AddKorongTest()
        {
            Rud rud3 = new Rud(new Korong("kek", 3), new Korong("piros", 2));
            Assert.That(rud3.GetKorongok().Count(), Is.EqualTo(2));
            Assert.That(rud3.GetKorongok().Last().GetSzin(), Is.EqualTo("piros"));
            Assert.That(rud3.GetKorongok().Last().GetAtmero(), Is.EqualTo(2));
            bool isSucessful = rud3.AddKorong(new Korong("kek", 1));
            Assert.That(isSucessful, Is.True);
            Assert.That(rud3.GetKorongok().Count(), Is.EqualTo(3));
            Assert.That(rud3.GetKorongok().Last().GetSzin(), Is.EqualTo("kek"));
            Assert.That(rud3.GetKorongok().Last().GetAtmero(), Is.EqualTo(1));
        }

        [Test]
        public void AddKorongUresRudraTest()
        {
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(0));
            bool isSucessful = rud2.AddKorong(new Korong("piros", 1));
            Assert.That(isSucessful, Is.True);
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(1));
            Assert.That(rud2.GetKorongok().Last().GetSzin(), Is.EqualTo("piros"));
            Assert.That(rud2.GetKorongok().Last().GetAtmero(), Is.EqualTo(1));
        }

        [Test]
        public void AddKorongRosszSorrendTest1()
        {
            rud2.AddKorong(new Korong("piros", 1));
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(1));
            bool isSucessful = rud2.AddKorong(new Korong("kek", 2));
            Assert.That(isSucessful, Is.False);
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddKorongRosszSorrendTest2()
        {
            rud2.AddKorong(new Korong("piros", 1));
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(1));
            bool isSucessful = rud2.AddKorong(new Korong("kek", 8));
            Assert.That(isSucessful, Is.False);
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddKorongAzonosSzinTest()
        {
            rud2.AddKorong(new Korong("piros", 2));
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(1));
            bool isSucessful = rud2.AddKorong(new Korong("piros", 1));
            Assert.That(isSucessful, Is.True);
            Assert.That(rud2.GetKorongok().Count(), Is.EqualTo(2));
        }

        [Test]
        public void CheckSorrendTest()
        {
            Assert.That(rud1.GetKorongok().Last().GetAtmero(), Is.EqualTo(1));
            bool isInSorrend = rud1.CheckSorrend();
            Assert.That(isInSorrend, Is.True);
        }

        [Test]
        public void CheckSorrendRosszTest1()
        {
            rud2.AddKorong(new Korong("kek", 4));
            rud2.AddKorong(new Korong("kek", 2));
            rud2.AddKorong(new Korong("kek", 3));
            rud2.AddKorong(new Korong("kek", 1));
            Assert.That(rud2.GetKorongok().Last().GetAtmero(), Is.EqualTo(1));
            bool isInSorrend = rud2.CheckSorrend();
            Assert.That(isInSorrend, Is.False);
        }
    }
}
