using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Ül5 {
    class Program {
        static void Main(string[] args) {
            Program p = new Program();
            p.Andmed();
            p.KirjutaAndmed();
            p.KirjutaAutoAndmed();
            p.KirjutaJalgrattaAndmed();
        }

        public List<AndmeTabel> Andmed() {
            List<AndmeTabel> andmeTabel = new List<AndmeTabel>();
            andmeTabel.Add(new AndmeTabel() {
                Id = "0",
                KüttusePaagiMahtuvus = "5l",
                ReisijateArv = "5",
                Tootja = "Ford",
                UsteArv = "5",
                TranspordiVahend = "Auto"
            });
            andmeTabel.Add(new AndmeTabel() {
                Id = "1",
                Tootja = "Scott",
                ReisijateArv = "1",
                SadulaKõrgus = "5.2 cm",
                TranspordiVahend = "Jalgratas"
            });
            andmeTabel.Add(new AndmeTabel() {
                Id = "2",
                KüttusePaagiMahtuvus = "4l",
                ReisijateArv = "5",
                Tootja = "Audi",
                UsteArv = "5",
                TranspordiVahend = "Auto"
            });
            andmeTabel.Add(new AndmeTabel() {
                Id = "3",
                Tootja = "Merida",
                ReisijateArv = "1",
                SadulaKõrgus = "5.5 cm",
                TranspordiVahend = "Jalgratas"
            });
            return andmeTabel;
        }

        public List<Auto> LisaAutoTabelisse() {
            var andmed = Andmed();
            List<Auto> autoTabel = new List<Auto>();
            foreach (var a in andmed) {
                if (a.TranspordiVahend == "Auto") {
                    autoTabel.Add(new Auto() {
                        Id = a.Id,
                        KüttusePaagiMahtuvus = a.KüttusePaagiMahtuvus,
                        ReisijateArv = a.ReisijateArv,
                        Tootja = a.Tootja,
                        UsteArv = a.UsteArv
                    });
                }
            }

            return autoTabel;
        }

        public List<Jalgratas> LisaJalgratasTabelisse() {
            var andmed = Andmed();
            List<Jalgratas> jalgrattaTabel = new List<Jalgratas>();
            foreach (var a in andmed) {
                if (a.TranspordiVahend == "Jalgratas") {
                    jalgrattaTabel.Add(new Jalgratas() {
                        Id = a.Id,
                        SadulaKõrgus = a.SadulaKõrgus,
                        ReisijateArv = a.ReisijateArv,
                        Tootja = a.Tootja
                    });
                }
            }

            return jalgrattaTabel;
        }

        public void KirjutaJalgrattaAndmed() {
            foreach (var a in LisaJalgratasTabelisse()) {
                Console.Write(" Id: " + a.Id +
                              " ReisijateArv: " + a.ReisijateArv +
                              " Tootja: " + a.Tootja +
                              " SadulaKõrgus: " + a.SadulaKõrgus);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void KirjutaAndmed() {
            foreach (var a in Andmed()) {
                Console.Write(" Id: " + a.Id +
                              " ReisijateArv: " + a.ReisijateArv +
                              " Tootja: " + a.Tootja +
                              " KüttusePaagiMahtuvus: " + a.KüttusePaagiMahtuvus +
                              " UsteArv: " + a.UsteArv +
                              " SadulaKõrgus: " + a.SadulaKõrgus +
                              " TranspordiVahend: " + a.TranspordiVahend);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void KirjutaAutoAndmed() {
            foreach (var a in LisaAutoTabelisse()) {
                Console.Write(" Id: " + a.Id +
                              " ReisijateArv: " + a.ReisijateArv +
                              " Tootja: " + a.Tootja +
                              " KüttusePaagiMahtuvus: " + a.KüttusePaagiMahtuvus +
                              " UsteArv: " + a.UsteArv);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
