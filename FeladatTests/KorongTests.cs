

namespace FeladatTests
{
    public class KorongTests
    {
        Korong korong;

        [SetUp]
        public void Setup()
        {
            korong = new Korong("kek", 1);
        }

        [Test]
        public void KorongSzinTest()
        {
            Assert.That("kek", Is.EqualTo(korong.GetSzin()));
        }

        [Test]
        public void KorongAtmeroTest() {
            Assert.That(1, Is.EqualTo(korong.GetAtmero()));
        }
    }
}