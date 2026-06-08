using Testy;

namespace UnitTest
{
    public class SystemIOT_SerwerHTTP_Tests
    {

        [Fact]
        public void OverDueCode()
        {
            SystemIOT_SerwerHTTP instance = new SystemIOT_SerwerHTTP();
            instance.czasDizałaniaKodu = 1000;


            ushort Code = instance.GenerujKodZnakowy();
            instance.UpdateListaAktualnychKodow();
            Thread.Sleep(3000);
            instance.UpdateListaAktualnychKodow();

            Assert.Equal(instance.WalidacjaKodu(Code), false);
        }



        [Fact]
        public void CodeIsValid()
        {
            SystemIOT_SerwerHTTP instance = new SystemIOT_SerwerHTTP();

            ushort Code = instance.GenerujKodZnakowy();

            Assert.Equal(instance.WalidacjaKodu(Code), true);
        }


        [Fact]
        public void CodeNotOwverDued()
        {
            SystemIOT_SerwerHTTP instance = new SystemIOT_SerwerHTTP();
            instance.czasDizałaniaKodu = 1000;


            ushort Code = instance.GenerujKodZnakowy();
            Thread.Sleep(500);
            instance.UpdateListaAktualnychKodow();

            Assert.Equal(instance.WalidacjaKodu(Code), true);
        }


        [Fact]
        public void CodeOutOfRange()
        {
            SystemIOT_SerwerHTTP instance = new SystemIOT_SerwerHTTP();
            instance.czasDizałaniaKodu = 1000;


            ushort Code = 10000;
            Assert.ThrowsAny<CodeOutOfRange>(()=>instance.WalidacjaKodu(Code));

        }

        [Fact]
        public void PinLengthTest()
        {
            SystemIOT_SerwerHTTP instance = new SystemIOT_SerwerHTTP();

            instance.PinLen = 2;

            Assert.Equal(instance.GenerujKodZnakowy()<99, true);
        }


        [Fact]
        public void SetPinLenThrowException()
        {
            SystemIOT_SerwerHTTP instance = new SystemIOT_SerwerHTTP();
            Assert.ThrowsAny<CodeOutOfRange>(() => { instance.PinLen = -1; });
        }
    }
}
