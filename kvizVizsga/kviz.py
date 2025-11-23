import json
import unicodedata
import random
import os
from datetime import datetime
import time

try:
    from colorama import init, Fore, Style
    init(autoreset=True)
    SZIN_ZOLD = Fore.GREEN
    SZIN_PIROS = Fore.RED
    SZIN_SARGA = Fore.YELLOW
    SZIN_CYAN = Fore.CYAN
    SZIN_RESET = Style.RESET_ALL
except ImportError:
    SZIN_ZOLD = ""
    SZIN_PIROS = ""
    SZIN_SARGA = ""
    SZIN_CYAN = ""
    SZIN_RESET = ""

def ekezet_torlese(szoveg: str) -> str:
    if not isinstance(szoveg, str): return str(szoveg)
    szoveg = unicodedata.normalize('NFD', szoveg)
    return ''.join(c for c in szoveg if unicodedata.category(c) != 'Mn')


class Kerdes:
    def __init__(self, Kerdes: str, Valasz, Pont: float, **kwargs):
        self.kerdes = Kerdes
        self.valasz = Valasz
        self.pont = float(Pont)
        self.kwargs = kwargs
    
    def ellenorzes(self, kapott_valasz: str) -> tuple[float, str]:
        tiszta_kapott = ekezet_torlese(kapott_valasz).strip().lower()
        tiszta_helyes = ekezet_torlese(self.valasz).strip().lower()
        
        if tiszta_kapott == tiszta_helyes:
            return self.pont, "Tökéletes válasz!"
        return 0.0, f"Helyes válasz: {self.valasz}"

    def megjelenites(self):
        print(f"\n{SZIN_CYAN}{self.kerdes}{SZIN_RESET} (Max: {self.pont} pont)")

class SzovegesKerdes(Kerdes):
    pass

class SzamKerdes(Kerdes):
    def ellenorzes(self, kapott_valasz: str) -> tuple[float, str]:
        try:
            kapott = float(kapott_valasz)
            helyes = float(self.valasz)
            elteres = abs(kapott - helyes)
            max_hiba = abs(helyes * 0.10)
            
            if elteres == 0:
                return self.pont, "Tökéletes!"
            elif elteres <= max_hiba:
                arany = 1.0 - (elteres / max_hiba)
                return self.pont * arany, f"Közel volt! ({elteres:.2f} eltérés)"
            else:
                return 0.0, f"Túl nagy eltérés. Helyes: {self.valasz}"
        except ValueError:
            return 0.0, "Nem számot adtál meg!"

class LebegopontosKerdes(SzamKerdes):
    pass

class ValasztosKerdes(Kerdes):
    def __init__(self, Kerdes, Valasz, Pont, Valasztek: list, **kwargs):
        super().__init__(Kerdes, Valasz, Pont, **kwargs)
        self.valasztek = Valasztek

    def megjelenites(self):
        print(f"\n{SZIN_CYAN}{self.kerdes}{SZIN_RESET} (Max: {self.pont} pont)")
        for i, opcio in enumerate(self.valasztek):
            print(f"  {i+1}. {opcio}")

    def ellenorzes(self, kapott_valasz: str) -> tuple[float, str]:
        kapott_valasz = kapott_valasz.strip()
        if kapott_valasz.isdigit():
            index = int(kapott_valasz) - 1
            if 0 <= index < len(self.valasztek):
                if self.valasztek[index] == self.valasz:
                    return self.pont, "Helyes!"
        return super().ellenorzes(kapott_valasz)

class HalmazKerdes(Kerdes):
    def ellenorzes(self, kapott_valasz: str) -> tuple[float, str]:
        if not kapott_valasz: return 0.0, "Üres válasz."
        
        felhasznalo_tippek = [ekezet_torlese(x.strip().lower()) for x in kapott_valasz.split(',')]
        helyes_valaszok_orig = [ekezet_torlese(x.strip().lower()) for x in self.valasz]
        helyes_valaszok_temp = helyes_valaszok_orig.copy()
        
        talalatok = 0
        for tipp in felhasznalo_tippek:
            if tipp in helyes_valaszok_temp:
                talalatok += 1
                helyes_valaszok_temp.remove(tipp)
        
        if not helyes_valaszok_orig: return 0.0, "Hiba a kérdésben."
        
        arany = talalatok / len(self.valasz)
        pont = self.pont * (1.0 if arany > 1.0 else arany)
        
        msg = f"{talalatok} elemet találtál el a(z) {len(self.valasz)}-ból."
        if pont == self.pont: msg = "Minden elemet eltaláltál!"
        else: msg += f" Hiányzó/Rossz: {len(self.valasz) - talalatok} db."
        
        return pont, msg

class DatumKerdes(Kerdes):
    def ellenorzes(self, kapott_valasz: str) -> tuple[float, str]:
        try:
            datum_helyes = datetime.strptime(self.valasz, '%Y-%m-%d')
            datum_kapott = None
            for fmt in ['%Y-%m-%d', '%Y.%m.%d', '%Y.%m.%d.']:
                try: datum_kapott = datetime.strptime(kapott_valasz.strip(), fmt); break
                except ValueError: continue
            
            if not datum_kapott: return 0.0, "Rossz dátum formátum!"
            
            elteres_nap = abs((datum_kapott - datum_helyes).days)
            max_elteres = 30
            
            if elteres_nap == 0: return self.pont, "Pontos dátum!"
            elif elteres_nap <= max_elteres:
                pont = self.pont * (1.0 - (elteres_nap / max_elteres))
                return pont, f"{elteres_nap} nap eltérés."
            else: return 0.0, f"Túl nagy eltérés ({elteres_nap} nap). Helyes: {self.valasz}"
        except Exception: return 0.0, "Hiba történt."

class IgazHamisKerdes(Kerdes):
    def ellenorzes(self, kapott_valasz: str) -> tuple[float, str]:
        inp = ekezet_torlese(kapott_valasz).strip().lower()
        if inp in ['i', 'igaz', 't', 'true', 'igen', 'y', 'yes', '1']: u_bool = True
        elif inp in ['h', 'hamis', 'f', 'false', 'nem', 'n', 'no', '0']: u_bool = False
        else: return 0.0, "Érvénytelen válasz (Igen/Nem kell)."
        
        h_bool = self.valasz
        if not isinstance(h_bool, bool):
             h_bool = (ekezet_torlese(str(self.valasz)).lower() in ['i', 'igaz', 't', 'true', 'igen', 'y', 'yes', '1'])
        
        if u_bool == h_bool: return self.pont, "Helyes!"
        return 0.0, "Rossz válasz."


class Kviz:
    def __init__(self, fajl_nev: str):
        self.TIPUS_MAPPING = {
            'szam': SzamKerdes,
            'szoveges': SzovegesKerdes,
            'valasztos': ValasztosKerdes,
            'halmaz': HalmazKerdes,
            'lebegopontos': LebegopontosKerdes,
            'date': DatumKerdes,
            'igazhamis': IgazHamisKerdes
        }
        self.fajl_nev = fajl_nev
        osszes_kerdes = self.kerdesek_betoltese()
        
        kerdesek_szama = 10
        if len(osszes_kerdes) > kerdesek_szama:
            self.kerdesek = random.sample(osszes_kerdes, kerdesek_szama)
        else:
            self.kerdesek = osszes_kerdes
            random.shuffle(self.kerdesek)

    def kerdesek_betoltese(self) -> list:
        kerdesek_lista = []
        try:
            with open(self.fajl_nev, 'r', encoding='utf-8') as file:
                adatok = json.load(file)
                for adat in adatok:
                    cls = self.TIPUS_MAPPING.get(adat.get('Tipus'))
                    if cls: kerdesek_lista.append(cls(**adat))
        except FileNotFoundError: print(f"{SZIN_PIROS}A kérdésfájl ({self.fajl_nev}) nem található!{SZIN_RESET}")
        except json.JSONDecodeError: print(f"{SZIN_PIROS}Hibás JSON formátum!{SZIN_RESET}")
        return kerdesek_lista

    def inditas(self):
        if not self.kerdesek:
            print("Nincsenek betölthető kérdések.")
            return

        osszes_pont = 0.0
        max_pont = sum(k.pont for k in self.kerdesek)
        eredmeny_naplo = []
        
        kezd_ido = time.time()

        print("\n" + "="*40)
        print(f"{SZIN_SARGA}KVÍZ JÁTÉK - {len(self.kerdesek)} kérdés{SZIN_RESET}")
        print("="*40)

        for i, kerdes in enumerate(self.kerdesek):
            print(f"\n--- {i+1}. kérdés ---", end="")
            kerdes.megjelenites()
            
            prompt = "Válasz: "
            if isinstance(kerdes, HalmazKerdes): prompt = "Válasz (vesszővel): "
            elif isinstance(kerdes, DatumKerdes): prompt = "Válasz (ÉÉÉÉ-HH-NN): "
            
            valasz = input(prompt)
            
            szerzett_pont, uzenet = kerdes.ellenorzes(valasz)
            osszes_pont += szerzett_pont
            
            eredmeny_naplo.append({
                'kerdes': kerdes.kerdes,
                'valasz': valasz,
                'helyes': str(kerdes.valasz),
                'pont': szerzett_pont,
                'max': kerdes.pont,
                'msg': uzenet
            })

            if szerzett_pont == kerdes.pont:
                print(f"{SZIN_ZOLD} {uzenet} (+{szerzett_pont:.1f}){SZIN_RESET}")
            elif szerzett_pont > 0:
                print(f"{SZIN_SARGA} {uzenet} (+{szerzett_pont:.2f}){SZIN_RESET}")
            else:
                print(f"{SZIN_PIROS} {uzenet} (0 pont){SZIN_RESET}")
        
        eltelt_ido = time.time() - kezd_ido
        perc = int(eltelt_ido // 60)
        masodperc = int(eltelt_ido % 60)
        
        szazalek = (osszes_pont / max_pont * 100) if max_pont > 0 else 0
        
        ertekeles = "Gyakorolj még!"
        if szazalek > 90: ertekeles = "Zseniális vagy!"
        elif szazalek > 75: ertekeles = "Szép munka!"
        elif szazalek > 50: ertekeles = "Nem rossz."

        zaroszoveg = (f"VÉGEREDMÉNY: {osszes_pont:.2f} / {max_pont} pont ({szazalek:.1f}%)\n"
                      f"Idő: {perc} perc {masodperc} mp - {ertekeles}")
        
        print("\n" + "-" * 40)
        print(f"{SZIN_SARGA}{zaroszoveg}{SZIN_RESET}")
        print("-" * 40)
        
        self.eredmeny_mentese(eredmeny_naplo, zaroszoveg, eltelt_ido)

    def eredmeny_mentese(self, naplo, zaroszoveg, eltelt_ido):
        idopont_str = datetime.now().strftime("%Y-%m-%d_%H-%M-%S")
        mappa = "eredmenyek"
        
        if not os.path.exists(mappa):
            os.makedirs(mappa)
            
        fajlnev = f"{mappa}/kviz_eredmeny_{idopont_str}.txt"
        
        try:
            with open(fajlnev, "w", encoding="utf-8") as f:
                f.write(f"KVÍZ EREDMÉNYEK\n{'='*30}\n")
                f.write(f"Dátum: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
                f.write(f"Kitöltési idő: {eltelt_ido:.1f} másodperc\n\n")
                
                for i, t in enumerate(naplo):
                    f.write(f"{i+1}. {t['kerdes']}\n")
                    f.write(f"   Válasz: {t['valasz']}\n")
                    f.write(f"   Eredmény: {t['pont']:.2f}/{t['max']} - {t['msg']}\n")
                    f.write("-" * 20 + "\n")
                
                f.write(f"\n{zaroszoveg}\n")
            
            print(f"(Részletes eredmény mentve: {fajlnev})")
            
        except Exception as e:
            print(f"{SZIN_PIROS}Hiba a mentésnél: {e}{SZIN_RESET}")


if __name__ == "__main__":
    while True:
        os.system('cls' if os.name == 'nt' else 'clear')
        
        kviz = Kviz('kerdesek.json')
        kviz.inditas()
        
        ujra = input("\nSzeretnél újra játszani? (igen/nem): ").strip().lower()
        if ujra not in ['igen', 'i', 'y', 'yes']:
            print("Viszlát!")
            break