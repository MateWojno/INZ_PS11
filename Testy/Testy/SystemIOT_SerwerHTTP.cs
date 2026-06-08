using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Testy
{
    public class SystemIOT_SerwerHTTP
    {
        public string Ip;
        public long czasDizałaniaKodu = 5600;
        public List<KodOtwarciaDrzwi> KodyLista = new List<KodOtwarciaDrzwi>();
        private int _pinLen=4;
        public int PinLen 
            {
            get{
                return _pinLen;
            }
            set
            {
                if (value <= 0) throw (new CodeOutOfRange());
                _pinLen = value;
            }
        }



        public ushort GenerujKodZnakowy()
        {
            while (true) 
            {
                ushort code = (ushort)new Random((int)DateTime.Now.Ticks).Next(0, (int)Math.Pow(10, _pinLen) - 1);

                if (!KodyLista.Any(x => x.KodNumeryczny == code))
                {
                    KodyLista.Add(new KodOtwarciaDrzwi()
                    {
                        KodNumeryczny = code,
                        DataWystawienia = DateTime.Now
                    });
                    return code;
                }
            }
        }
        
        public void UpdateListaAktualnychKodow()
        {
            if (DateTime.Now > KodyLista[0].DataWystawienia.AddSeconds((int)czasDizałaniaKodu / 1000))
            {
                KodyLista.Remove(KodyLista[0]);
            }
        }

        public bool WalidacjaKodu(ushort code)
        {
            if(code < 0 ||code > 9999)
            {
                throw (new CodeOutOfRange());
            }


            if(KodyLista.Exists(x=>x.KodNumeryczny == code))
            {
                return true;
            }
            return false;
        }
    }
}
