Lavet af Johannes Forsting, Rasmus Ørum, Nicolas Alvi.

Vi har oprettet klassen Club, som indeholde info om hodlet og alt dens statestik for de kampe den har spillet.
Vi har oprettet klassen League som indeholder info om ligaen samt en liste af Klubber. 

Når programmet starter bliver de 12 hold indlæst og de 3 ligaer (Superliga, mesterskabsspil, samt kvalifikationsspil).
til at starte med bliver alle 12 hold tilført i en liste til superligaen, mens de 2 andre ligaer inderholder en tom list.

Runderne bliver derefter kørt 1 efter 1 fra hver deres CSV fil. For hver runde bliver alle kampe konfigureret og alle holds stats bliver opdateret alt efter antal mål, resultat osv.
Efter hver runde bliver resultatet for denne runde printet til kosollen samt den nuværende stilling i ligaen.
Ligaens resultater bliver sorteret på følgende i given rækkefølge:

- Antal Point
- Målforskel
- Mål scoret
- Mål scoret imod (Denne er ikke taget med da det er overflødigt. Hvis målforskel og mål scoret er ens vil mål imod også være ens.)
- alfabetisk rækkefølge.

Efter 22 runder vil de 6 øverste hold blive tilført mesterskabsspillet-objectet og visa versa med de 6 bund hold i kvalifikationsspillet-objectet.

Mesterskabsspillet indeholder følgende pladser:
- 1 CHL
- 2 EUL
- 1 EUCL

kvalifikationsspillet indeholder følgende pladser:
- 2 nedrykningspladser

De sidste 10 runder bliver derefter kørt på samme måde da vi referere til Club objekterne. Derfor har den liga de er i faktisk ingen indflydelse på denne del.
